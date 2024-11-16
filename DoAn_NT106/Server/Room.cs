using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server;
namespace TCPServer
{
    //Quản lý phòng chơi
    public class Room
    {
        public string RoomId { get; set; }
        // trạng thái bàn cờ 
        public string CurrentBoardState { get; set; }
        //socket chứa client của người chơi
        public List<Socket> Players { get; set; }
        public TcpClient Client1 { get; set; }
        public TcpClient Client2 { get; set; }
        public NetworkStream Stream1 { get; set; }
        public NetworkStream Stream2 { get; set; }


        public Room(TcpClient client1, TcpClient client2)
        {
          Client1 = client1;
          Client2 = client2;
          Stream1 = client1.GetStream();
          Stream2 = client2.GetStream();
        }

        public void SendToClient1(string message)
        {
           byte[] buffer = Encoding.ASCII.GetBytes(message);
           Stream1.Write(buffer, 0, buffer.Length);
        }

        public void SendToClient2(string message)
        {
           byte[] buffer = Encoding.ASCII.GetBytes(message);
           Stream2.Write(buffer, 0, buffer.Length);
        }

        public Room(string roomId)
        {
            RoomId = roomId;
            CurrentBoardState = "initial_board_state"; // Trạng thái khởi tạo của bàn cờ
            Players = new List<Socket>();
        }
        // them người chơi vào phòng
        public void AddPlayer(Socket playerSocket)
        {
            if (Players.Count < 2)
            {
                Players.Add(playerSocket);
            }
        }
        // gửi đường đi quân cờ
        public void Broadcast(string message)
        {
            foreach (var player in Players)
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                player.Send(data);
            }
        }
    }
}