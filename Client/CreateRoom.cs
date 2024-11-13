using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateRoom : Form
    {
        private Socket clientSocket;
        private int click = 0;
        public CreateRoom()
        {
            InitializeComponent();
            RoomId();
            ConnectToServer();
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
                byte[] data = System.Text.Encoding.UTF8.GetBytes(choice);
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


        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void W_Click(object sender, EventArgs e)
        {
            click++;
            MessageBox.Show("YOU ARE WHITE");
            W.Enabled = false;
            label3.Text = click + "/2";
            SendChoiceToServer("WHITE");
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

            string roomId = textBox1.Text;
            string message = $"CREATE_ROOM:{roomId}";
            SendChoiceToServer(message);

            ChessWindow newGame = new ChessWindow();
            newGame.Show();
            this.Hide();
        }
    }
}
