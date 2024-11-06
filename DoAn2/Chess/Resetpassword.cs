using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace Chess
{
    public partial class Resetpassword : Form
    {
        private string Email;
        private bool isPasswordVisible = false;
        public Resetpassword(string email)
        {
            Email= email;
            InitializeComponent();
        }
        public Resetpassword()
        {
            InitializeComponent();
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
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
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

        private async void Comfirm_btn_Click(object sender, EventArgs e)
        {
            string password = Passdecode(Password_txt.Text);
            string comfirm = Passdecode(Comfirm_txt.Text);
            string ServerIp = "127.0.0.1";
            int port = 11000;

            if (password != comfirm)
            {
                MessageBox.Show("Xác nhận không khớp vui lòng nhập lại!");
                return;
            }

            try
            {
                using (Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);

                    
                    await Task.Run(() => Client.Connect(endPoint));

                    var Signuppacket = new Packet("ChangePasswordRequest", "", "", "", password, Email);
                    string packetString = Signuppacket.ToPacketString();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);

                    
                    await Task.Run(() => Client.Send(messageBytes));

                    byte[] buffer = new byte[512];

                  
                    int bytesRead = await Task.Run(() => Client.Receive(buffer));
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Packet receivedPacket = Packet.FromPacketString(response);
                    if (receivedPacket.Request == "ChangePasswordResponse")
                    {
                        if (receivedPacket.Message == "ChangeSuccessful")
                        {
                            MessageBox.Show("Thay đổi thành công");
                        }
                        else if (receivedPacket.Message == "ChangeFailed")
                        {
                            MessageBox.Show("Thay đổi thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void ShowPassword_btn_Click(object sender, EventArgs e)
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

        private void ShowComfirm_btn_Click_1(object sender, EventArgs e)
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
    }
}
