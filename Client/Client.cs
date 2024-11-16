using Client;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Program
{
    public class Client
    {
        private Socket clientSocket;
        private Thread recvThread;
        private bool isConnected;

        private string serverAddress = "127.0.0.1"; // Địa chỉ IP của Server
        private int serverPort = 11000;

       
        public Client()
        {
            clientSocket = null;
            recvThread = null;
            isConnected = false;
        }

        public void Connect()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(serverAddress), serverPort));
                isConnected = true;

                // Bắt đầu một luồng để nhận dữ liệu
                recvThread = new Thread(ReceiveMove);
                recvThread.IsBackground = true;
                recvThread.Start();

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kết nối server: " + ex.Message);
                isConnected = false;
            }
        }

        public void SendData(MovePacket move)
        {
            try
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                      byte[] moveData = move.ToByteArray();

            // Gửi dữ liệu qua socket
            clientSocket.Send(moveData);
                }
                else
                {
                    Console.WriteLine("Không thể gửi dữ liệu: Client chưa kết nối.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }

        private void ReceiveMove()
        {
            try
            {
                while (isConnected && clientSocket.Connected)
                {
                    byte[] buffer = new byte[256];
                    int bytesRead = clientSocket.Receive(buffer);

                    if (bytesRead > 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        HandleServerResponse(response); // Gọi phương thức xử lý phản hồi từ server
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi nhận dữ liệu: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        private void HandleServerResponse(string response)
        {
            Packet receivedPacket = Packet.FromPacketString(response);

            if (receivedPacket.Request == "START_GAME")
            {
                // Khởi động trò chơi nếu phòng đã đủ người chơi
                ChessWindow newGame = new ChessWindow();
                newGame.Show();
                Application.OpenForms[0].Hide(); // Ẩn Form chính hiện tại
            }
            else if (receivedPacket.Request == "WAITING_FOR_PLAYER")
            {
                MessageBox.Show("Đợi người chơi khác tham gia...");
            }
            else if (receivedPacket.Request == "ROOM_FULL")
            {
                MessageBox.Show("Phòng đã đầy, vui lòng chọn phòng khác.");
            }
        }

        public void CloseConnection()
        {
            try
            {
                isConnected = false;

                if (recvThread != null && recvThread.IsAlive)
                {
                    recvThread.Join(); // Đợi luồng hoàn thành
                }

                if (clientSocket != null && clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }

                Console.WriteLine("Đã đóng kết nối.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đóng kết nối: {ex.Message}");
            }
        }
    }
}
