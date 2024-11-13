using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Program
{
    public class Client
    {
        private Socket clientSocket;
        private Thread recvThread;
        private bool isConnected;

        public event Action<string> OnMoveReceived; // Sự kiện khi nhận được nước đi từ server

        public Client()
        {
            clientSocket = null;
            recvThread = null;
            isConnected = false;
        }

        public void Connect(string ipAddress, int port)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                isConnected = true;

                // Bắt đầu một luồng để nhận dữ liệu
                recvThread = new Thread(ReceiveMove);
                recvThread.IsBackground = true;
                recvThread.Start();

                Console.WriteLine("Connected to server at " + ipAddress + ":" + port);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kết nối server: " + ex.Message);
                isConnected = false;
            }
        }

        public void SendData(string data)
        {
            try
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    clientSocket.Send(dataBytes);
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
                        string moveData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        OnMoveReceived?.Invoke(moveData);
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
