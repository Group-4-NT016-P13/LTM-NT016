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
using static excercise_2.login;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Net;

namespace excercise_2
{
    public partial class signup : Form
    {
        
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
        public static bool checkmail(string email)
        {
            string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, Pattern);
        }

        public signup()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox4.Text;
            string password = Passdecode(textBox2.Text);
            string confirm = Passdecode(textBox3.Text);
            string ServerIp = "192.168.1.10";
            int port = 11000;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (name(username))
            {
                MessageBox.Show("Tên đã tồn tại");
                return;
            }
            if (password.Length < 5)
            {
                MessageBox.Show("Mật Khẩu Yếu!");
                return;
            }
            if (!Regex.IsMatch(email, "@gmail.com"))
            {
                MessageBox.Show("Không hợp lệ!");
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Lỗi Mật Khẩu!");
                return;
            }
            if (!checkmail(email))
            {
                MessageBox.Show("Email không đúng định dạng , Nhập lại.");
                return;
            }
            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);


            string message = username + ":" + password + ":" + email + ":" + confirm;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            Client.Send(messageBytes);



            byte[] buffer = new byte[256];
            int bytesRead = Client.Receive(buffer);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            string[] parts = response.Split(':');
            if (parts.Length >= 3)
            {
                string ReturnResponse = parts[0];
                string ReturnUsername = parts[1];
                string ReturnEmail = parts[2];

                if (ReturnResponse == "SignupSuccessful")
                {
                    infor log = new infor(ReturnUsername, ReturnEmail);
                    log.Show();
                    this.Hide();
                }
                else if (ReturnResponse == "SignupFailed")
                {
                    MessageBox.Show("Thông tin đăng nhập không đúng, vui lòng nhập lại.");
                }
            }



            Client.Shutdown(SocketShutdown.Both);
            Client.Close();

        }
        public bool name(string username)
        {
            string ServerIp = "192.168.1.10";
            int port = 11000;

            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);

            // Gửi yêu cầu kiểm tra tên người dùng
            string request = "CheckUsername:" + username;
            byte[] requestBytes = Encoding.ASCII.GetBytes(request);
            Client.Send(requestBytes);

            // Nhận phản hồi từ máy chủ
            byte[] buffer = new byte[256];
            int bytesRead = Client.Receive(buffer);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Đóng kết nối
            Client.Shutdown(SocketShutdown.Both);
            Client.Close();

            // Xử lý phản hồi
            return response == "Ten ton tai";
        }

    }
}
