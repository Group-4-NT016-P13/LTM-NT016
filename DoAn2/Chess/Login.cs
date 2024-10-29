using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chess
{
    public partial class Login : Form
    {
        private bool isPasswordVisible = false;
        public Login()
        {
            InitializeComponent();

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
        private void Label_MouseEnter(object sender, EventArgs e)
        {

            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Blue;
                label.ForeColor = Color.White;
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {

            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
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
        private void Login_btn_Click(object sender, EventArgs e)
        {
            string username = Username_txt.Text;
            string password = Passdecode(Password_txt.Text);
            string ServerIp = "127.0.0.1";
            int port = 11000;

            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);


            string message = "LoginRequest" + ":" + username + ":" + password;
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

        private void Signup_lb_Click(object sender, EventArgs e)
        {
            Signup log = new Signup();
            log.Show();
            this.Hide();
        }

        private void Forgot_lb_Click(object sender, EventArgs e)
        {

        }
    }
}
 
