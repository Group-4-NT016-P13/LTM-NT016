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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chess
{
    public partial class Infor : Form
    {
        private readonly string User_Username;
        private string ChangedNickname;
        private string ChangedEmail;
        private readonly string OldNickname;
        private readonly string OldEmail;
        public Infor()
        {
            InitializeComponent();
        }
        public Infor(string Username,string Nickname,string Email)
        {
            OldNickname= Nickname;
            OldEmail= Email;
            User_Username = Username;
            InitializeComponent();
            Nickname_txt.Text = Nickname;
            Email_txt.Text = Email;
        }

        private void Fix_btn_Click(object sender, EventArgs e)
        {
            ChangedNickname = Nickname_txt.Text;
            ChangedEmail = Email_txt.Text;
            string ServerIp = "127.0.0.1";
            int port = 11000;

            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            Client.Connect(endPoint);

            var Changedpacket = new Packet("ChangedRequest", "", User_Username, ChangedNickname, "", ChangedEmail);
            string packetString = Changedpacket.ToPacketString();

           
            byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);
            Client.Send(messageBytes);

            byte[] buffer = new byte[512];
            int bytesRead = Client.Receive(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Packet Recievedpacket = Packet.FromPacketString(response);
            if(Recievedpacket.Request == "ChangedResponse")
            {
                if(Recievedpacket.Message == "ChangedSuccessful")
                {
                    Menu MenuAfterChanged = new Menu(User_Username,ChangedNickname, ChangedEmail);
                    MenuAfterChanged.Show();
                    this.Hide();
                }
                else if(Recievedpacket.Message == "ChangedFailedEmail")
                {
                    MessageBox.Show("Email đã tồn tại vui lòng nhập lại ");
                    
                }
                else if (Recievedpacket.Message == "ChangedFailed")
                {
                    MessageBox.Show("Lỗi thay đổi vui lòng thử lại ");

                }

            }
            Client.Shutdown(SocketShutdown.Both);
            Client.Close();
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Menu newMenu = new Menu(User_Username,OldNickname,OldEmail);
            newMenu.Show();
            this.Hide();
        }
    }
}
