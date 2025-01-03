﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace chess
{
    internal class TCPServer
    {
        public enum PieceColor
        {
            White,
            Black
        }
        
        private TcpListener tcpListener;
        private const string connectionString = "Data Source=players.db;Version=3;";
        private List<GameRoom> randomRoom = new List<GameRoom>();
        private Dictionary<string, GameRoom> rooms = new Dictionary<string, GameRoom>();// tạo phòng bình thường

        public TCPServer(int localPort)
        {
            tcpListener = new TcpListener(IPAddress.Any, localPort);
            CreateDatabase();// gói hàm tạo database
        }

        public async Task StartServer()
        {
            tcpListener.Start();
            Console.WriteLine("Server dang khoi dong, cho doi ket noi...");

            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine($"Client ket noi: {client.Client.RemoteEndPoint}");
                _ = HandleClient(client); // Xử lý mỗi client trong một task riêng biệt
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Console.WriteLine($"Nhan yeu cau: {request}");
                    string response = ProcessRequest(request, client);

                    byte[] responseData = Encoding.UTF8.GetBytes(response + "\n");
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (client.Connected)
                {
                    client.Close();
                }
                Console.WriteLine("Client ngat ket noi.");
            }
        }

        private string ProcessRequest(string request, TcpClient client)
        {
            string[] parts = request.Split(' ');
            string command = parts[0].ToUpper(); // Chuyển sang chữ hoa để so sánh không phân biệt chữ hoa chữ thường

            switch (command)
            {
                // xử lí liên quan đến đăng nhập đăng ký
                case "REGISTER":
                    return parts.Length >= 4 ? RegisterPlayer(parts[1], parts[2], parts[3]) : "ERROR: yêu cầu không rõ";
                case "LOGIN":
                    return parts.Length >= 3 ? LoginPlayer(parts[1], parts[2]) : "ERROR: yêu cầu không rõ";
                case "CHECK":
                    return parts.Length >= 2 ? CheckMail(parts[1]) : "ERROR: yêu cầu không rõ";
                case "UPDATE_PASSWORD":
                    return parts.Length >= 3 ? UpdatePassword(parts[1], parts[2]) : "ERROR: yêu cầu không rõ";
                case "LOGOUT":
                    return parts.Length >=2 ? LogoutPlayer(parts[1]) : "ERROR: yêu cầu không rõ";
                case "UPDATE":
                    return parts.Length >= 2 ? GetRating(parts[1]).ToString() : "ERROR: yêu cầu không rõ";
                //xử lí liên quan đến game
                case "MOVE":
                    return parts.Length >= 3 ? HandleMove(parts[1], parts[2], client) : "ERROR: yêu cầu nước đi không rõ";
                case "CHAT":
                    return parts.Length >= 2 ? HandleChat(string.Join(" ", parts.Skip(1)), client) : "ERROR: tin nhắn rỗng";
                case "CREATE_ROOM":
                    return parts.Length >= 4 ? CreateRoom(parts[1], parts[2], parts[3], parts[4],client) : "ERROR: Không thể tạo";
                case "FIND_ROOM":
                    return parts.Length >= 2 ? JoinRoom(parts[1], parts[2] ,client) : "ERROR: yêu cầu không rõ";
                case "CREATE_RANDOM_ROOM":
                    return parts.Length >= 4 ? CreateRandomRoom(parts[1],parts[2], parts[3], parts[4], client) : "ERROR: yêu cầu không rõ";
                case "FIND_RANDOM_ROOM":
                    return parts.Length >= 2 ? JoinRandomRoom(parts[1], client) : "ERROR: yêu cầu không rõ";
                case "GAME_OVER":
                    return parts.Length >=5 ? GameOver(parts[1], parts[2], parts[3], parts[4],client) : "ERROR: yêu cầu không rõ";
                default:
                    return "ERROR: Không rõ lệnh";
            }
        }

        private string RegisterPlayer(string username, string password,string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO players (Username, Password, Email, Rating, IsLoggedIn) VALUES (@username, @password, @email, 1200, 1)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    try
                    {
                        command.ExecuteNonQuery();

                        return $"SUCCESS: đăng ký {username} {email} 1200";
                    }
                    catch (SQLiteException ex)
                    {
                        // Lỗi khóa duy nhất (unique constraint)
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            return "ERROR: Tên đăng nhập hoặc Email đã tồn tại";
                        }
                        return "ERROR: Lỗi Database: " + ex.Message;
                    }
                }
            }
        }
  


        private string LoginPlayer(string username, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Câu truy vấn duy nhất để lấy cả ID và rank
                string query = "SELECT Username,Email,Rating,IsLoggedIn FROM players WHERE Username = @username AND Password = @password";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            string Username = reader.GetString(0);  
                            string Email = reader.GetString(1);  
                            int Rating = reader.GetInt32(2);
                            int IsLoggedIn = reader.GetInt32(3);
                            if (IsLoggedIn == 1)
                            {
                                return "ERROR: tài khoản đã được đăng nhập ở nơi khác.";
                            }
                            UpdateLoginStatus(username, true, connection);
                            return $"SUCCESS: đăng nhập {Username} {Email} {Rating}";
                        }
                        else
                        {
                            return "ERROR: Tên Đăng Nhập không đúng";
                        }
                    }
                }
            }
        }
        private string LogoutPlayer(string username)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                UpdateLoginStatus(username, false, connection);
                return $"SUCCESS: {username} đã đăng xuất.";
            }
        }
        private void UpdateLoginStatus(string username, bool isLoggedIn, SQLiteConnection connection)
        {
            string query = "UPDATE players SET IsLoggedIn = @isLoggedIn WHERE Username = @username";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@isLoggedIn", isLoggedIn ? 1 : 0);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
            }
        }

        private string CheckMail(string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                 
                string query = "SELECT COUNT(*) FROM players WHERE Email = @Email";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    // Thực thi truy vấn và lấy kết quả
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        return "SUCCESS: Email tồn tại";
                    }
                    else
                    {
                        return "ERROR: Email không tìm thấy";
                    }
                }
            }
        }
        private string UpdatePassword(string password,string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Kiểm tra xem email có tồn tại hay không
                string checkQuery = "SELECT COUNT(*) FROM players WHERE Email = @Email";

                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        return "ERROR: Email không tìm thấy";
                    }
                }

                // Nếu email tồn tại, cập nhật mật khẩu
                string updateQuery = "UPDATE players SET Password = @Password WHERE Email = @Email";

                using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Password", password);
                    updateCommand.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "SUCCESS: đã cập nhật";
                    }
                    else
                    {
                        return "ERROR: cập nhật thất bại";
                    }
                }
            }
        }
        private void UpdateRating(string username, int ratingChange)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Kiểm tra xem username có tồn tại hay không
                string checkQuery = "SELECT COUNT(*) FROM players WHERE Username = @Username";

                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        Console.WriteLine("ERROR: khong tim thay nguoi dung");
                    }
                }

                // Nếu username tồn tại, cập nhật rating
                string updateQuery = "UPDATE players SET Rating = Rating + @RatingChange WHERE Username = @Username";

                using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@RatingChange", ratingChange);
                    updateCommand.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("SUCCESS: diem duoc cap nhat");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: cap nhat that bai");
                    }
                }
            }
        }

        private string GetRating(string username)
        {
            int? rating;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Truy vấn để lấy Rating theo username
                string query = "SELECT Rating FROM players WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        rating = Convert.ToInt32(result);
                    }
                    else
                    {
                        rating = null; // Username không tồn tại hoặc Rating không có giá trị
                    }
                }
            }
            return $"COMPLETE {rating}";
        }
        private string GetRatingForRoom(string username)
        {
            int? rating;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Truy vấn để lấy Rating theo username
                string query = "SELECT Rating FROM players WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        rating = Convert.ToInt32(result);
                    }
                    else
                    {
                        rating = null; // Username không tồn tại hoặc Rating không có giá trị
                    }
                }
            }
            return rating.ToString();
        }

        private string CreateRoom(string roomid,string piececolor,string time,string username,TcpClient client)
        {
            lock (rooms)
            {
                if (rooms.ContainsKey(roomid))
                {
                    return "ERROR: Phòng đã tồn tại";
                }

                var newRoom = new GameRoom(client);
                newRoom.SetTime(time);
                newRoom.SetP1Color(piececolor);
                newRoom.SetP1Username(username);
                rooms[roomid] = newRoom;
                return $"SUCCESS: Room {roomid} đã tạo";
            }
        }

        private string JoinRoom(string roomId,string username ,TcpClient client)
        {
            string RoomTime;
            lock (rooms)
            {
                if (!rooms.ContainsKey(roomId))
                {
                    return "ERROR: Phòng không tồn tại";
                }

                var existingRoom = rooms[roomId];

                // Kiểm tra nếu client đã ở trong phòng
                if (existingRoom.HasPlayer(client))
                {
                    return "ERROR: bạn đang ở trong phòng";
                }

                // Kiểm tra nếu phòng đã đầy
                if (existingRoom.IsFull())
                {
                    return "ERROR: Phòng đã đầy";
                }
                RoomTime = existingRoom.GetTime();
                // Thêm người chơi vào phòng
                existingRoom.AddPlayer(client);
                existingRoom.SetP2Username(username);
                string P1_Color = existingRoom.P1Color();
                string P2_Color = (P1_Color == "WHITE") ? "BLACK" : "WHITE";
                string P1_Username = existingRoom.GetP1Username();
                string P2_Username = existingRoom.GetP2Username();
                string P1_Rating = GetRatingForRoom(P1_Username);
                string P2_Rating = GetRatingForRoom(P2_Username);
                existingRoom.SetP2Color(P2_Color);
                existingRoom.SetIndexByColor();
                SendMessage(existingRoom.GetLastPlayer(), $"START {P1_Color} {P2_Username} {P2_Rating}");
                return $"SUCCESS: {P2_Color} {P1_Username} {P1_Rating} {roomId} {RoomTime}";
            }
        }
        private string CreateRandomRoom(string roomid,string piececolor, string time, string username, TcpClient client)
        {
            lock (randomRoom)
            {
                var newRoom = new GameRoom(client);
                newRoom.SetTime(time);
                newRoom.SetP1Color(piececolor);
                newRoom.SetP1Username(username);
                newRoom.SetRoomId(roomid);
                randomRoom.Add(newRoom);
                return $"SUCCESS: Room {roomid} đã tạo";
            }
        }
        private string JoinRandomRoom(string username, TcpClient client)
        {
            lock (randomRoom)
            {
                foreach( var room in randomRoom)
                {
                    if(!room.IsFull())
                    {
                        if (room.HasPlayer(client))
                        {
                            return "ERROR: Bạn đang ở trong phòng này";
                        }
                        room.AddPlayer(client);
                        room.SetP2Username(username);
                        string RoomTime = room.GetTime();
                        string P1_Color = room.P1Color();
                        string RoomId = room.GetRoomId();
                        string P2_Color = (P1_Color == "WHITE") ? "BLACK" : "WHITE";
                        string P1_Username = room.GetP1Username();
                        string P2_Username = room.GetP2Username();
                        string P1_Rating = GetRatingForRoom(P1_Username);
                        string P2_Rating = GetRatingForRoom(P2_Username);
                        room.SetP2Color(P2_Color);
                        room.SetIndexByColor();
                        SendMessage(room.GetLastPlayer(), $"START {P1_Color} {P2_Username} {P2_Rating}");
                        return $"SUCCESS: {P2_Color} {P1_Username} {P1_Rating} {RoomId} {RoomTime}";
                    }    
                }
                return "ERROR: Không có phòng phù hợp để tham gia";
            }
        }

        private string GameOver(string roomid, string P_piececolor, string result, string username, TcpClient client)
        {
            GameRoom existingRoom = null;

           
            if (rooms.ContainsKey(roomid))
            {
                existingRoom = rooms[roomid];
            }
            else if(randomRoom.Any(r=>r.HasPlayer(client)))
            {
                existingRoom = randomRoom.FirstOrDefault(r => r.HasPlayer(client));
            }    
      
            if (existingRoom == null)
            {
                return "ERROR: Phòng không tìm thấy";
            }

           
            string P1 = existingRoom.P1Color();
            string P2 = existingRoom.P2Color();
            string message = "GAMEOVER!!";

           
            if (result == "wins!")
            {
                if (P1 == P_piececolor)
                {
                    UpdateRating(username, 20);
                }
                if (P2 == P_piececolor)
                {
                    UpdateRating(username, 20);
                }
            }

            
            existingRoom.SendMessageToAll(message);

            
            if (rooms.ContainsKey(roomid))
            {
                rooms.Remove(roomid);
                Console.WriteLine("Xóa phòng  thành công");
            }
            if (randomRoom.Contains(existingRoom))
            {
                randomRoom.Remove(existingRoom);
                Console.WriteLine("Xóa phòng random thành công");
            }


            return message;
        }


        private string HandleMove(string from, string to, TcpClient client)
        {
            GameRoom room = null;

            lock (rooms)
            {
                room = rooms.Values.FirstOrDefault(g => g.HasPlayer(client));
            }

            if (room == null)
            {
                lock (randomRoom)
                {
                    room = randomRoom.FirstOrDefault(g => g.HasPlayer(client));
                }
            }

            if (room == null)
            {
                return "ERROR: không có phòng";
            }

            if (!room.IsCurrentPlayer(client))
            {
                return "ERROR: không phải lượt bạn";
            }

            room.SendMove(from, to, client);
            return "SUCCESS: Đã gửi nước đi";
        }
        private string HandleChat(string message, TcpClient client)
        {
            GameRoom room = null;
            lock (rooms)
            {
                room = rooms.Values.FirstOrDefault(g => g.HasPlayer(client));
            }

            if (room == null)
            {
                lock (randomRoom)
                {
                    room = randomRoom.FirstOrDefault(g => g.HasPlayer(client));
                }
            }

            if (room == null)
            {
                return "ERROR: không có phòng";
            }

            room.SendChatMessage(message, client);
            return "SUCCESS: Tin nhắn đã gửi";
        }

        private async void SendMessage(TcpClient client, string message)
         {
             try
             {
                 byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                 NetworkStream stream = client.GetStream();
                 await stream.WriteAsync(data, 0, data.Length);
                 await stream.FlushAsync();
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"loi gui tin nhan: {ex.Message}");
             }
         }
    
        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS players (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT UNIQUE,
                Password TEXT NOT NULL,
                Email TEXT UNIQUE,
                Rating INT DEFAULT 1200,
                IsLoggedIn INT DEFAULT 0
            );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                AddAdminUserIfNotExists(connection);
            }
        }
        private void AddAdminUserIfNotExists(SQLiteConnection connection)
        {
            string checkQuery = "SELECT COUNT(*) FROM players WHERE Username = 'admin'";
            using (var command = new SQLiteCommand(checkQuery, connection))
            {
                long count = (long)command.ExecuteScalar();
                if (count == 0)
                {
                    string insertQuery = "INSERT INTO players (Username, Password, Email) VALUES ('admin','123','admin12@gmail.com')";
                    using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("da them addmin");
                    }
                }
            }
        }


       

    }

}