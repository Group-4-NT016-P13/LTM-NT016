using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;

namespace excercise_2
{
    public partial class login : Form
    {
       
           public class UserInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
        public static string Passdecode(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            signup log = new signup();
            log.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = Passdecode(textBox2.Text);
            string ServerIp = "127.0.0.1";
            int port = 11000;

            Socket Client =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);


            string message = username + ":" + password;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            Client.Send(messageBytes);


            byte[] buffer = new byte[256];
            int bytesRead = Client.Receive(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string[] parts = response.Split(':');
            if (parts.Length >= 1)
            {
                string ReturnResponse = parts[0];
                if (ReturnResponse == "LoginSuccessful")
                {
                    if (parts.Length >= 3)
                    {
                        string ReturnUsername = parts[1];
                        string ReturnEmail = parts[2];
                        string ReturnName = parts[3];
                        string ReturnDate = parts[4];
                        infor log = new infor(ReturnUsername, ReturnEmail, ReturnName, ReturnDate);
                        log.Show();
                        this.Hide();
                    }
                }
                else if (ReturnResponse == "LoginFailed")
                {
                    MessageBox.Show("Thông tin đăng nhập không đúng, vui lòng nhập lại.");
                }
            }

            Client.Shutdown(SocketShutdown.Both);
            Client.Close();

        }
    }
}


