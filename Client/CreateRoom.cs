using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateRoom : Form
    {
        private Socket clientSocket;
        private Thread receiveThread;
        private int click = 0;

        public CreateRoom()
        {
            InitializeComponent();
            RoomId();
            ConnectToServer();
            StartReceiveThread();
        }

        private void ConnectToServer()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect("127.0.0.1", 11000);
                MessageBox.Show("Kết nối đến server thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến server: " + ex.Message);
            }
        }

        private void SendChoiceToServer(string choice)
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                byte[] data = Encoding.UTF8.GetBytes(choice);
                clientSocket.Send(data);
            }
            else
            {
                MessageBox.Show("Không có kết nối với server!");
            }
        }
        private void RoomId(int length = 6)
        {
            Random random = new Random();
            string roomId = "";

            for (int i = 0; i < length; i++)
            {
                roomId += random.Next(0, 10).ToString();
            }

            textBox1.Text = roomId;
            textBox1.Enabled = false;
        }

       private void StartReceiveThread()
        {
            receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceiveData()
        {
            try
            {
                while (clientSocket != null && clientSocket.Connected)
                {
                    byte[] buffer = new byte[256];
                    int bytesRead = clientSocket.Receive(buffer);

                    if (bytesRead > 0)
                    {
                        string serverResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        HandleServerResponse(serverResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu từ server: " + ex.Message);
            }
        }

        private void HandleServerResponse(string response)
        {
            if (response == "WAITING_FOR_PLAYER")
            {
                MessageBox.Show("Đợi người chơi khác tham gia...");
            }
            else if (response == "ROOM_READY")
            {
                MessageBox.Show("Phòng đã sẵn sàng! Bắt đầu trò chơi.");
                Invoke((MethodInvoker)delegate {
                    ChessWindow newGame = new ChessWindow();
                    newGame.Show();
                    this.Hide();
                });
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            CloseConnection();
            this.Close();
        }

        private void CloseConnection()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        private void W_Click(object sender, EventArgs e)
        {
            click++;
            MessageBox.Show("YOU ARE WHITE");
            W.Enabled = false;
            label3.Text = click + "/2";
         //   SendChoiceToServer("WHITE");
        }

        private void B_Click(object sender, EventArgs e)
        {
            click++;
            MessageBox.Show("YOU ARE BLACK");
            B.Enabled = false;
            label3.Text = click + "/2";
            SendChoiceToServer("BLACK");
        }

        private void ready_Click(object sender, EventArgs e)
        {
            if (click != 2)
            {
                MessageBox.Show("NOT READY");
                return;
            }

            ChessWindow game = new ChessWindow();
            game.Show();
        }
    }
}
