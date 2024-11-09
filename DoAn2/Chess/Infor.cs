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
using System.Threading;

namespace Chess
{
    public partial class Infor : Form
    {
        private Socket ClientSocket;
        private readonly string User_Username;
        private string ChangedNickname;
        private string ChangedEmail;
        private readonly string OldNickname;
        private readonly string OldEmail;
        private bool isFormOpen = true;
        private Task receiveTask;

        public Infor()
        {
            InitializeComponent();
        }
        public Infor(Socket clientsocket,string Username,string Nickname,string Email)
        {
            InitializeComponent();
            ClientSocket = clientsocket;
            OldNickname = Nickname;
            OldEmail= Email;
            User_Username = Username;
            Nickname_txt.Text = Nickname;
            Email_txt.Text = Email;

        }
       

        private async void Fix_btn_Click(object sender, EventArgs e)
        {
            ChangedNickname = Nickname_txt.Text;
            ChangedEmail = Email_txt.Text;
           

            Socket Client = ClientSocket;
            

            var Changedpacket = new Packet("ChangedRequest", "", User_Username, ChangedNickname, "", ChangedEmail);
            string packetString = Changedpacket.ToPacketString();

           
            byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);
            await Task.Run(() => Client.Send(messageBytes));
            if (receiveTask == null || receiveTask.IsCompleted)
            {
                receiveTask = Task.Run(() => ReceiveData());
            }
        }
        private async Task ReceiveData()
        {
            try
            {
                while (ClientSocket.Connected)
                {
                    byte[] buffer = new byte[512];
                    int bytesRead = await Task.Run(() => ClientSocket.Receive(buffer));
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Packet Recievedpacket = Packet.FromPacketString(response);
                    if (Recievedpacket.Request == "ChangedResponse")
                    {
                        if (isFormOpen)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (Recievedpacket.Message == "ChangedSuccessful")
                                {
                                    Menu MenuAfterChanged = new Menu(ClientSocket, User_Username, ChangedNickname, ChangedEmail);
                                    MenuAfterChanged.Show();
                                    this.Close();
                                }
                                else if (Recievedpacket.Message == "ChangedFailedEmail")
                                {
                                    MessageBox.Show("Email đã tồn tại vui lòng nhập lại.");
                                }
                                else if (Recievedpacket.Message == "ChangedFailed")
                                {
                                    MessageBox.Show("Lỗi thay đổi vui lòng thử lại.");
                                }
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (isFormOpen) 
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Menu newMenu = new Menu(ClientSocket,User_Username,OldNickname,OldEmail);
            newMenu.Show();
            this.Hide();
        }
    }
}
