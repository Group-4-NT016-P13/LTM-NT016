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


namespace TCPServer
{
    public partial class TCPServer : Form
    {
        string connectionString = "Data Source=DESKTOP-0PFOH9Q\\SQLEXPRESS;Initial Catalog=USERID_DB;Integrated Security=True;";
        private Socket listener;
        private bool running;
        public class UserInfo
        {
            public string Username { get; set; }
            public string Email { get; set; }
        }
        public TCPServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                LogMessage("Server đang chạy trên port " + port + "...");
                running = true;
                Thread listenerThread = new Thread(ListenForClients);
                listenerThread.IsBackground = true;
                listenerThread.Start();
            }
            catch (Exception ex)
            {
                LogMessage("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private void ListenForClients()
        {
            while (running)
            {
                try
                {
                    Socket clientSocket = listener.Accept();
                    LogMessage("Client đã kết nối!");
                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
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

        private void HandleClient(Socket clientSocket)
        {
            try
            {
                string response = "Failed";
                string username;
                string password;
                string email;
                byte[] buffer = new byte[256];
                int bytesRead = clientSocket.Receive(buffer);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                LogMessage("Đã nhận từ client: " + message);
                string[] parts = message.Split(':');

                if (parts.Length == 2) 
                {
                    username = parts[0];
                    password = parts[1];
                    UserInfo userInfo = GetInfo(username);
                    if (Login(username, password))
                    {
                        
                        response = $"LoginSuccessful:{userInfo.Username}:{userInfo.Email}";
                    }
                    else
                    {
                        response = "LoginFailed";
                    }
                }
                else if (parts.Length == 4) 
                {
                    username = parts[0];
                    password = parts[1];
                    email = parts[2];
                    string confirm = parts[3];
                    if (Signup(username))
                    {
                        response = "SignupFailedName";
                    }
                    else
                    {
                        string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                SqlCommand cmd = new SqlCommand(query, connection);
                                cmd.Parameters.AddWithValue("@Username", username);
                                cmd.Parameters.AddWithValue("@Password", password);
                                cmd.Parameters.AddWithValue("@Email", email);
                                int row = cmd.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    response = $"SignupSuccessful:{username}:{email}";
                                }
                                else
                                {
                                    response = "SignupFailed";
                                }
                            }
                            catch (Exception ex)
                            {
                                LogMessage("Lỗi khi đăng ký: " + ex.Message);
                                response = "SignupFailed";
                            }
                        }
                    }
                }

                byte[] responseData = Encoding.ASCII.GetBytes(response);
                clientSocket.Send(responseData);

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                LogMessage("Lỗi xử lý client: " + ex.Message);
            }
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
        private bool Signup(string username)
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
        private UserInfo GetInfo(string username)
        {
            UserInfo userInfo = null;
            string query = "SELECT UserId, Username, Email FROM Users WHERE Username = @Username";

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
                        Email = reader.GetString(2)
                    };
                }
            }
            return userInfo;
        }
    }
}
