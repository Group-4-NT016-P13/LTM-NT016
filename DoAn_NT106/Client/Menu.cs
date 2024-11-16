using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client
{
    public partial class Menu : Form
    {
        private Socket ClientSocket;
        private string User_Username;
        private string User_Nickname;
        private string User_Email;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(Socket clientsocket, string Username, string Nickname, string Email)
        {
            ClientSocket = clientsocket;
            User_Username = Username;
            User_Nickname = Nickname;
            User_Email = Email;
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            string toolTipText = $"Tên người dùng: {Nickname}\nEmail: {Email}";
            toolTip.SetToolTip(UserInfo, toolTipText);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserInfo_Click(object sender, EventArgs e)
        {
            Infor log = new Infor(ClientSocket, User_Username, User_Nickname, User_Email);
            log.ShowDialog();
            this.Hide();
        }

        private async void Close_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var ShutdownPacket = new Packet("ShutdownRequest", "", "", "", "", "");
                string packetString = ShutdownPacket.ToPacketString();

                byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);

                
                await Task.Run(() => ClientSocket.Send(messageBytes));

                
                byte[] buffer = new byte[256];
                int bytesRead = await Task.Run(() => ClientSocket.Receive(buffer));

                if (bytesRead > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Packet receivedPacket = Packet.FromPacketString(response);
                    if (receivedPacket.Request == "ShutdownResponse")
                    {
                        ClientSocket.Shutdown(SocketShutdown.Both);
                        ClientSocket.Close();
                        this.Close();
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Đóng kết nối: " + ex.Message);
            }
        }

        private void Createroom_btn_Click(object sender, EventArgs e)
        {
            CreateRoom room = new CreateRoom();
            room.Show();
            this.Hide();
        }
    }
}
