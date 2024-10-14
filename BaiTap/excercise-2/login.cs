﻿using System;
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
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = Passdecode(textBox2.Text);
            string ServerIp = "192.168.1.10";
            int port = 11000;

            Socket Client =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);


            string message = username + ":" + password;
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

                if (ReturnResponse == "LoginSuccessful")
                {
                    infor log = new infor(ReturnUsername,ReturnEmail);
                    log.Show();
                    this.Hide();
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


