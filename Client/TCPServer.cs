using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Server;


namespace TCPServer
{
    public partial class TCPServer : Form
    {
        string connectionString = "Data Source=DESKTOP-0PFOH9Q\\SQLEXPRESS;Initial Catalog=ChessServer_DB;Integrated Security=True;";
        private Socket listener;
        private bool running;
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        public class UserInfo
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Nickname { get; set; }
           
        }
        public TCPServer()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                int port = 11000;
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
                textBox1.Text = endPoint.ToString();
                listener.Bind(endPoint);
                listener.Listen(10);
                LogMessage("Server đang chạy ...");
                running = true;
                await ListenForClientsAsync();
            }
            catch (Exception ex)
            {
                LogMessage("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private async Task ListenForClientsAsync()
        {
            while (running)
            {
                try
                {
                    Socket clientSocket = await Task.Run(() => listener.Accept());
                    LogMessage("Client đã kết nối!");

                    // Khởi chạy xử lý client trong một task riêng biệt
                    _ = HandleClientAsync(clientSocket);
                }
                catch (SocketException ex)
                {
                    if (running)
                    {
                        LogMessage("Lỗi kết nối client: " + ex.Message);
                    }
                }
            }
        }

        private async Task HandleClientAsync(Socket clientSocket)
        {
            try
            {
                while (clientSocket.Connected)
                {
                    try
                    {
                        byte[] buffer = new byte[512];
                        int bytesRead = await Task.Run(() => clientSocket.Receive(buffer));

                        if (bytesRead == 0)
                        {
                            LogMessage("Client đã đóng kết nối.");
                            break;
                        }

                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        LogMessage("Đã nhận từ client: " + message);

                        Packet receivedPacket;
                        try
                        {
                            receivedPacket = Packet.FromPacketString(message);
                        }
                        catch (Exception ex)
                        {
                            LogMessage("Lỗi phân tích cú pháp gói tin: " + ex.Message);
                            continue;
                        }

                        string response;

                        if (receivedPacket.Request == "ShutdownRequest")
                        {
                            response = new Packet("ShutdownResponse", "", "", "", "", "").ToPacketString();
                            byte[] shutdownMessage = Encoding.UTF8.GetBytes(response);
                            await Task.Run(() => clientSocket.Send(shutdownMessage));
                            LogMessage("Client đã yêu cầu tắt kết nối.");
                            break;
                        }
                        else
                        {
                            response = HandleRequest(receivedPacket);
                            byte[] responseData = Encoding.UTF8.GetBytes(response);
                            await Task.Run(() => clientSocket.Send(responseData));
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage("Lỗi trong vòng lặp xử lý client: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("Lỗi xử lý client: " + ex.Message);
            }
            finally
            {
                clientSocket.Close();
                LogMessage("Client đã ngắt kết nối.");
            }
        }
        private string UpdateBoardState(Packet receivedPacket)
        {
            if (rooms.TryGetValue(receivedPacket.RoomId, out Room room))
            {
                room.CurrentBoardState = receivedPacket.BoardState;
                room.Broadcast(new Packet("MovePieceResponse", "Success", "", "", receivedPacket.BoardState, "").ToPacketString());
                return new Packet("MovePieceResponse", "Success", "", "", "", "").ToPacketString();
            }
            else
            {
                return new Packet("MovePieceResponse", "RoomNotFound", "", "", "", "").ToPacketString();
            }
        }

        private string JoinRoom(string roomId, Socket clientSocket)
        {
            Room room = CreateRoom(roomId);
            if (room.Players.Count < 2)
            {
                room.AddPlayer(clientSocket);
                LogMessage($"Người chơi đã tham gia phòng {roomId}");

                if (room.Players.Count == 2)
                {
                    room.Broadcast("Cả hai người chơi đã sẵn sàng. Trận đấu bắt đầu!");
                }

                return new Packet("JoinRoomResponse", "Success", roomId, "", "", "").ToPacketString();
            }
            else
            {
                return new Packet("JoinRoomResponse", "RoomFull", "", "", "", "").ToPacketString();
            }
        }
        private Room CreateRoom(string roomId)
        {
            if (!rooms.ContainsKey(roomId))
            {
                Room newRoom = new Room(roomId);
                rooms[roomId] = newRoom;
                LogMessage("Phòng mới đã được tạo: " + roomId);
            }
            return rooms[roomId];
        }
      
        //------------------------------------------------------------------

        private string HandleRequest(Packet receivedPacket)
        {
            string response = string.Empty;

            switch (receivedPacket.Request)
            {
                case "LoginRequest":
                    response = LoginRequest(receivedPacket);
                    break;

                case "SignupRequest":
                    response = SignupRequest(receivedPacket);
                    break;

                case "ChangedRequest":
                    response = ChangeRequest(receivedPacket);
                    break;

                case "CheckRequest":
                    response = CheckRequest(receivedPacket);
                    break;

                case "ChangePasswordRequest":
                    response = ChangePasswordRequest(receivedPacket);
                    break;
                case "JoinRoomRequest":
                    response = JoinRoom(receivedPacket.RoomId, listener);
                    break;

                case "MovePieceRequest":
                    response = UpdateBoardState(receivedPacket);
                    break;
            }

            return response;
        }

        private string LoginRequest(Packet receivedPacket)
        {
            string response;
            UserInfo userinfor = GetInfo(receivedPacket.Username);
            if (Login(receivedPacket.Username, receivedPacket.Password))
            {
                response = new Packet("LoginResponse", "LoginSuccessful", userinfor.Username, userinfor.Nickname, "", userinfor.Email).ToPacketString();
            }
            else
            {
                response = new Packet("LoginResponse", "LoginFailed", "", "", "", "").ToPacketString();
            }
            return response;
        }

        private string SignupRequest(Packet receivedPacket)
        {
            string response;

            if (SignupUsername(receivedPacket.Username))
            {
                response = new Packet("SignupResponse", "SignupFailedName", "", "", "", "").ToPacketString();
            }
            else if (SignupEmail(receivedPacket.Email))
            {
                response = new Packet("SignupResponse", "SignupFailedEmail", "", "", "", "").ToPacketString();
            }
            else
            {
                response = AddNewUser(receivedPacket);
            }
            return response;
        }

        private string AddNewUser(Packet receivedPacket)
        {
            string response;
            string query = "INSERT INTO Users (Username, Nickname, Password, Email) VALUES (@Username, @Nickname, @Password, @Email)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", receivedPacket.Username);
                    cmd.Parameters.AddWithValue("@Nickname", receivedPacket.Nickname);
                    cmd.Parameters.AddWithValue("@Password", receivedPacket.Password);
                    cmd.Parameters.AddWithValue("@Email", receivedPacket.Email);
                    int row = cmd.ExecuteNonQuery();
                    response = row > 0 ?
                               new Packet("SignupResponse", "SignupSuccessful", "", "", "", "").ToPacketString() :
                               new Packet("SignupResponse", "SignupFailed", "", "", "", "").ToPacketString();
                }
                catch (Exception ex)
                {
                    LogMessage("Lỗi khi đăng ký: " + ex.Message);
                    response = new Packet("SignupResponse", "SignupFailed", "", "", "", "").ToPacketString();
                }
            }
            return response;
        }

        private string ChangeRequest(Packet receivedPacket)
        {
            string response;

            if (IsEmailExsits(receivedPacket.Username, receivedPacket.Email))
            {
                response = new Packet("ChangedResponse", "ChangedFailedEmail", "", "", "", "").ToPacketString();
            }
            else
            {
                string query = @"UPDATE Users SET Nickname = @Nickname, Email = @Email WHERE Username = @Username";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Username", receivedPacket.Username);
                        cmd.Parameters.AddWithValue("@Nickname", receivedPacket.Nickname);
                        cmd.Parameters.AddWithValue("@Email", receivedPacket.Email);
                        int row = cmd.ExecuteNonQuery();
                        response = row > 0 ?
                                   new Packet("ChangedResponse", "ChangedSuccessful", "", "", "", "").ToPacketString() :
                                   new Packet("ChangedResponse", "ChangedFailed", "", "", "", "").ToPacketString();
                    }
                    catch (Exception ex)
                    {
                        LogMessage("Lỗi khi thay đổi: " + ex.Message);
                        response = new Packet("ChangedResponse", "ChangedFailed", "", "", "", "").ToPacketString();
                    }
                }
            }
            return response;
        }

        private string CheckRequest(Packet receivedPacket)
        {
            return SignupEmail(receivedPacket.Email) ?
                   new Packet("CheckResponse", "Found", "", "", "", "").ToPacketString() :
                   new Packet("CheckResponse", "Not Found", "", "", "", "").ToPacketString();
        }

        private string ChangePasswordRequest(Packet receivedPacket)
        {
            string response;

            if (SignupEmail(receivedPacket.Email))
            {
                string query = @"UPDATE Users SET Password = @Password WHERE Email = @Email";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Email", receivedPacket.Email);
                        cmd.Parameters.AddWithValue("@Password", receivedPacket.Password);
                        int row = cmd.ExecuteNonQuery();
                        response = row > 0 ?
                                   new Packet("ChangePasswordResponse", "ChangeSuccessful", "", "", "", "").ToPacketString() :
                                   new Packet("ChangePasswordResponse", "ChangeFailed", "", "", "", "").ToPacketString();
                    }
                    catch (Exception ex)
                    {
                        LogMessage("Lỗi khi thay đổi mật khẩu: " + ex.Message);
                        response = new Packet("ChangePasswordResponse", "ChangeFailed", "", "", "", "").ToPacketString();
                    }
                }
            }
            else
            {
                response = new Packet("ChangePasswordResponse", "EmailNotFound", "", "", "", "").ToPacketString();
            }

            return response;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (running)
            {
                running = false;
                listener?.Close();
                LogMessage("Server đã dừng.");
            }
        }

        private void LogMessage(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBox1.AppendText(message + Environment.NewLine);
            }
        }
        private bool Login(string username, string password)
        {
            string coded = password;
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", coded);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private bool SignupUsername(string username)
        {

            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private bool SignupEmail(string email)
        {

            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private bool IsEmailExsits(string username,string email)
        { 
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Username != @Username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Username", username);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private UserInfo GetInfo(string username)
        {
            UserInfo userInfo = null;
            string query = "SELECT UserId, Username, Email,Nickname FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userInfo = new UserInfo
                    {
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Nickname = reader.GetString(3),
                    };
                }
            }
            return userInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
