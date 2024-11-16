using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPServer;

namespace Server
{
    public class Connect2player
    {
        private static Room room;
        private static TcpListener listener;
        private static TcpClient client1, client2;
        private static NetworkStream stream1, stream2;
        private static byte[] buffer = new byte[1024];


        public Connect2player(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            listener.Start();

            // Chấp nhận kết nối từ client 1
            client1 = listener.AcceptTcpClient();
            stream1 = client1.GetStream();
            

            // Chấp nhận kết nối từ client 2
            client2 = listener.AcceptTcpClient();
            stream2 = client2.GetStream();
           

            // Tạo phòng và gán client vào phòng
            room = new Room(client1, client2);

            // Gửi thông báo cho các client biết họ đã vào phòng
            room.SendToClient1("You are in the room. Waiting for the game to start...");
            room.SendToClient2("You are in the room. Waiting for the game to start...");

            // Bắt đầu trò chơi (hoặc chỉ thông báo sẵn sàng)
            StartGame();
        }
        private void StartGame()
        {
            // Gửi thông điệp bắt đầu trò chơi
            room.SendToClient1("START_GAME");

            // Gửi thông báo cho Client 2
            room.SendToClient2("START_GAME");
            // Logic xử lý các bước đi trong trò chơi
            HandleGamePlay();
        }
        private void HandleGamePlay()
        {
            while (true)
            {
                try
                {
                    // Đọc và xử lý các bước đi từ client 1
                    string moveFromClient1 = ReadMessage(room.Stream1);

                    // Gửi bước đi của client 1 cho client 2
                    room.SendToClient2("Client 1 move: " + moveFromClient1);

                    // Đọc và xử lý các bước đi từ client 2
                    string moveFromClient2 = ReadMessage(room.Stream2);

                    // Gửi bước đi của client 2 cho client 1
                    room.SendToClient1("Client 2 move: " + moveFromClient2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error during game play: " + ex.Message);
                    break;
                }
            }
        }

        private string ReadMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }
    }
}
