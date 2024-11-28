using System;
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
        private Queue<TcpClient> waitingPlayers = new Queue<TcpClient>();
        private const string connectionString = "Data Source=players.db;Version=3;";
        private List<GameRoom> gameRooms = new List<GameRoom>();
        private Dictionary<string, GameRoom> rooms = new Dictionary<string, GameRoom>();

        public TCPServer(int localPort)
        {
            tcpListener = new TcpListener(IPAddress.Any, localPort);
            CreateDatabase();
        }

        public async Task StartAsync()
        {
            tcpListener.Start();
            Console.WriteLine("Server started, waiting for connections...");

            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client); // Xử lý mỗi client trong một task riêng biệt
            }
        }

        private async Task HandleClientAsync(TcpClient client)
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
                    Console.WriteLine($"Received: {request}");
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
                    RemovePlayer(client);
                }
                Console.WriteLine("Client disconnected.");
            }
        }

        private string ProcessRequest(string request, TcpClient client)
        {
            string[] parts = request.Split(' ');
            string command = parts[0].ToUpper(); // Chuyển sang chữ hoa để so sánh không phân biệt chữ hoa chữ thường

            switch (command)
            {
                case "REGISTER":
                    return parts.Length >= 4 ? RegisterPlayer(parts[1], parts[2], parts[3]) : "ERROR: Invalid request format";
                case "LOGIN":
                    return parts.Length >= 3 ? LoginPlayer(parts[1], parts[2]) : "ERROR: Invalid request format";
                case "FIND_MATCH":
                    return FindMatch(client);
                case "MOVE":
                    return parts.Length >= 3 ? HandleMove(parts[1], parts[2], client) : "ERROR: Invalid move format";
                case "CHAT":
                    return parts.Length >= 2 ? HandleChat(string.Join(" ", parts.Skip(1)), client) : "ERROR: Empty message";
                case "UPDATE":
                    return UpdatePlayerRank(int.Parse(parts[1]), int.Parse(parts[2]));
                case "CREATEROOM":
                    return parts.Length >= 2 ? CreateRoom(parts[1], client) : "ERROR: Cant Create";
                case "FINDROOM":
                    return parts.Length >= 2 ? JoinRoom(parts[1], client) : "ERROR: Invalid request format";
                case "CHECK":
                    return parts.Length >= 2 ? CheckMail(parts[1]) : "ERROR: Invalid request format";
                case "UPDATEPASSWORD":
                    return parts.Length >= 3 ? UpdatePassword(parts[1], parts[2]) : "ERROR: Invalid request format";
                default:
                    return "ERROR: Unknown command";
            }
        }

        private string RegisterPlayer(string username, string password,string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO players (Username, Password, Email, Rating) VALUES (@username, @password, @email, 1200)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    try
                    {
                        command.ExecuteNonQuery();
                        return $"SUCCESS: Logged in {username} {email} 1200";
                    }
                    catch (SQLiteException ex)
                    {
                        // Lỗi khóa duy nhất (unique constraint)
                        if (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            return "ERROR: Username or Password already exists";
                        }
                        return "ERROR: Database error: " + ex.Message;
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
                string query = "SELECT Username,Email,Rating FROM players WHERE Username = @username AND Password = @password";

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
                            return $"SUCCESS: Logged in {Username} {Email} {Rating}";
                        }
                        else
                        {
                            return "ERROR: Invalid username or password";
                        }
                    }
                }
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
                        return "SUCCESS: Email exists";
                    }
                    else
                    {
                        return "ERROR: Email not found";
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
                        return "ERROR: Email not found";
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
                        return "SUCCESS: Password updated";
                    }
                    else
                    {
                        return "ERROR: Password update failed";
                    }
                }
            }
        }

        private string CreateRoom(string roomid,TcpClient client)
        {
            lock (rooms)
            {
                if (rooms.ContainsKey(roomid))
                {
                    return "ERROR: Room already exists.";
                }

                var newRoom = new GameRoom(client);
                rooms[roomid] = newRoom;
                return $"SUCCESS: Room {roomid} created.";
            }
        }

        private string JoinRoom(string roomId, TcpClient client)
        {
            lock (rooms)
            {
                if (!rooms.ContainsKey(roomId))
                {
                    return "ERROR: Room does not exist.";
                }

                var existingRoom = rooms[roomId];

                // Kiểm tra nếu client đã ở trong phòng
                if (existingRoom.HasPlayer(client))
                {
                    return "ERROR: You are already in this room.";
                }

                // Kiểm tra nếu phòng đã đầy
                if (existingRoom.IsFull())
                {
                    return "ERROR: Room is already full.";
                }

                // Thêm người chơi vào phòng
                existingRoom.AddPlayer(client);
                SendMessage(existingRoom.GetLastPlayer(), "START WHITE");
                return $"SUCCESS: BLACK {roomId}";
            }
        }


        private string FindMatch(TcpClient client)
        {
            lock (waitingPlayers)
            {
                // Kiểm tra xem client đã có trong danh sách người chơi hay chưa
                if (waitingPlayers.Contains(client))
                {
                    return "ERROR: Already in a match";
                }

                waitingPlayers.Enqueue(client);
                if (waitingPlayers.Count >= 2)
                {
                    TcpClient player1 = waitingPlayers.Dequeue();
                    TcpClient player2 = waitingPlayers.Dequeue();
                    GameRoom gameRoom = new GameRoom(player1, player2);
                    gameRooms.Add(gameRoom);

                    SendMessage(player1, "MATCH_FOUND WHITE");
                    SendMessage(player2, "MATCH_FOUND BLACK");
                    SendMessage(player1, "MATCH_FOUND WHITE");
                    //  SendMessageBoardState(player1, gameRoom);
                    // SendMessageBoardState(player2, gameRoom);

                    return "SUCCESS: Match started";
                }
                else
                {
                    return "WAITING: Finding match...";
                }
            }
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
                lock (gameRooms)
                {
                    room = gameRooms.FirstOrDefault(g => g.HasPlayer(client));
                }
            }

            if (room == null)
            {
                return "ERROR: Not in a game room.";
            }

            if (!room.IsCurrentPlayer(client))
            {
                return "ERROR: Not your turn";
            }

            room.SendMove(from, to, client);
            return "SUCCESS: Move sent";
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
                lock (gameRooms)
                {
                    room = gameRooms.FirstOrDefault(g => g.HasPlayer(client));
                }
            }

            if (room == null)
            {
                return "ERROR: Not in a game room.";
            }

            room.SendChatMessage(message, client);
            return "SUCCESS: Message sent";
        }

        private void RemovePlayer(TcpClient client)
        {
            lock (waitingPlayers)
            {
                if (waitingPlayers.Contains(client))
                {
                    waitingPlayers = new Queue<TcpClient>(waitingPlayers.Where(p => p != client));
                }

                var room = gameRooms.FirstOrDefault(g => g.HasPlayer(client));
                if (room != null)
                {
                    room.RemovePlayer(client);
                    gameRooms.Remove(room);
                }
            }
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
                 Console.WriteLine($"Error sending message: {ex.Message}");
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
                Rating INT DEFAULT 1200
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
                        Console.WriteLine("Admin user added.");
                    }
                }
            }
        }


        private string UpdatePlayerRank(int playerId, int rankChange)
        {

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE players SET rank = rank + @rankChange WHERE id = @playerId";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@rankChange", rankChange);
                    command.Parameters.AddWithValue("@playerId", playerId);

                    command.ExecuteNonQuery();
                }
            }
            return "SUCCESS";
        }

    }

}