using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Chess
{
    public partial class Signup : Form
    {
        private string Username;
        private string Nickname;
        private string Email;
        private Socket Client;
        private bool isPasswordVisible = false;
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

        public Signup()
        {
            InitializeComponent();
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username_txt.Text))
            {

                Username_lb.Visible = true;
            }
            else
            {

                Username_lb.Visible = false;
            }
        }
        private void Nickname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nickname_txt.Text))
            {

                Nickname_lb.Visible = true;
            }
            else
            {

                Nickname_lb.Visible = false;
            }
        }
        private void Email_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_txt.Text))
            {

                Email_lb.Visible = true;
            }
            else
            {

                Email_lb.Visible = false;
            }
        }
        private void Comfirm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comfirm_txt.Text))
            {

                Comfirm_lb.Visible = true;
            }
            else
            {

                Comfirm_lb.Visible = false;
            }
        }
        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_txt.Text))
            {

                Password_lb.Visible = true;
            }
            else
            {

                Password_lb.Visible = false;
            }
        }

        private void ShowPassword_btn_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                Password_txt.PasswordChar = '\0';
            }
            else
            {
                Password_txt.PasswordChar = '*';
            }
        }

        private void ShowComfirm_btn_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                Comfirm_txt.PasswordChar = '\0';
            }
            else
            {
                Comfirm_txt.PasswordChar = '*';
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private async void Signup_btn_Click(object sender, EventArgs e)
        {
            Username = Username_txt.Text;
            Nickname = Nickname_txt.Text;
            Email = Email_txt.Text;
            string Password = Passdecode(Password_txt.Text);
            string Comfirm = Passdecode(Comfirm_txt.Text);
            string ServerIp = "127.0.0.1";
            int port = 11000;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Comfirm) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Nickname))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (Password.Length < 5)
            {
                MessageBox.Show("Mật Khẩu Yếu!");
                return;
            }
            if (Password != Comfirm)
            {
                MessageBox.Show("Lỗi Mật Khẩu!");
                return;
            }
            if (!checkmail(Email))
            {
                MessageBox.Show("Email không đúng định dạng , Nhập lại.");
                return;
            }

            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            await Task.Run(() => Client.Connect(endPoint));

            var Signuppacket = new Packet("SignupRequest","", Username, Nickname, Password, Email);
            string packetString = Signuppacket.ToPacketString();


            byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);
            await Task.Run(() => Client.Send(messageBytes));

            await ReceiveDataAsync();
        }
        private async Task ReceiveDataAsync()
        {
            try
            {
                while (Client.Connected)
                {
                    byte[] buffer = new byte[512];
                    int bytesRead = await Task.Run(() => Client.Receive(buffer));

                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Packet receivedPacket = Packet.FromPacketString(response);

                    if (receivedPacket.Request == "SignupResponse" && receivedPacket.Message == "SignupSuccessful")
                    {
                        Invoke(new Action(() =>
                        {
                            Menu Newmenu = new Menu(Client, Username, Nickname, Email);
                            Newmenu.Show();
                            this.Hide();
                        }));
                    }
                    else if (receivedPacket.Message == "SignupFailedName")
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng nhập lại.");
                    }
                    else if (receivedPacket.Message == "SignupFailedEmail")
                    {
                        MessageBox.Show("Email đã tồn tại, vui lòng nhập lại.");
                    }
                    else if (receivedPacket.Message == "SignupFailed")
                    {
                        MessageBox.Show("Lỗi Đăng ký, vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }


    }
}

       
