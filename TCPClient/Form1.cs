using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        private TcpClient clientPlayer1, clientPlayer2;
        private NetworkStream streamPlayer1, streamPlayer2;
        private bool isPlayer1Connected = false, isPlayer2Connected = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Connect Player 1
        private async void buttonConnectPlayer1_Click(object sender, EventArgs e)
        {
            if (!isPlayer1Connected)
            {
                await ConnectPlayerAsync("Player1", ref clientPlayer1, ref streamPlayer1, ref isPlayer1Connected);
            }
        }

        // Connect Player 2
        private async void buttonConnectPlayer2_Click(object sender, EventArgs e)
        {
            if (!isPlayer2Connected)
            {
                await ConnectPlayerAsync("Player2", ref clientPlayer2, ref streamPlayer2, ref isPlayer2Connected);
            }
        }

        private async Task ConnectPlayerAsync(string player, ref TcpClient client, ref NetworkStream stream, ref bool isConnected)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 11000);
                stream = client.GetStream();
                isConnected = true;
                LogMessage($"{player} connected to server");
                await ReceiveDataAsync(player, stream, ref isConnected);
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting {player}: " + ex.Message);
            }
        }

        private async void buttonSendRequestPlayer1_Click(object sender, EventArgs e)
        {
            await SendRequestAsync("Player1", clientPlayer1, streamPlayer1, isPlayer1Connected);
        }

        private async void buttonSendRequestPlayer2_Click(object sender, EventArgs e)
        {
            await SendRequestAsync("Player2", clientPlayer2, streamPlayer2, isPlayer2Connected);
        }

        private async Task SendRequestAsync(string player, TcpClient client, NetworkStream stream, bool isConnected)
        {
            if (isConnected)
            {
                Packet packet = new Packet($"{player}LoginRequest", "YourUsername", "YourPassword", "", "", "");
                string packetData = packet.ToPacketString();
                byte[] data = Encoding.UTF8.GetBytes(packetData);
                await stream.WriteAsync(data, 0, data.Length);
                LogMessage($"{player} sent request");
            }
            else
            {
                LogMessage($"{player} is not connected.");
            }
        }

        private async Task ReceiveDataAsync(string player, NetworkStream stream, ref bool isConnected)
        {
            byte[] buffer = new byte[512];
            while (isConnected)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        LogMessage($"{player} received: {response}");
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"{player} error receiving data: " + ex.Message);
                    isConnected = false;
                }
            }
        }

        private void LogMessage(string message)
        {
            if (richTextBoxLog.InvokeRequired)
            {
                richTextBoxLog.Invoke(new Action(() => richTextBoxLog.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBoxLog.AppendText(message + Environment.NewLine);
            }
        }

        // Disconnect both players
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectPlayer("Player1", ref clientPlayer1, ref streamPlayer1, ref isPlayer1Connected);
            DisconnectPlayer("Player2", ref clientPlayer2, ref streamPlayer2, ref isPlayer2Connected);
        }

        private void DisconnectPlayer(string player, ref TcpClient client, ref NetworkStream stream, ref bool isConnected)
        {
            if (isConnected)
            {
                stream?.Close();
                client?.Close();
                isConnected = false;
                LogMessage($"{player} disconnected from server");
            }
        }

        public class Packet
        {
            public string Request { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Nickname { get; set; }
            public string AdditionalInfo { get; set; }
            public string Email { get; set; }

            public Packet(string request, string username, string password, string nickname, string additionalInfo, string email)
            {
                Request = request;
                Username = username;
                Password = password;
                Nickname = nickname;
                AdditionalInfo = additionalInfo;
                Email = email;
            }

            public string ToPacketString()
            {
                return $"{Request}|{Username}|{Password}|{Nickname}|{AdditionalInfo}|{Email}";
            }
        }
    }
}
