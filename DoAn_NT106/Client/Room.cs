using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        public string RoomId { get; set; }
        public string CurrentBoardState { get; set; }
        public List<Socket> Players { get; set; }

        public Room(string roomId)
        {
            RoomId = roomId;
            CurrentBoardState = "initial_board_state"; // Trạng thái khởi tạo của bàn cờ
            Players = new List<Socket>();
        }

        public void AddPlayer(Socket playerSocket)
        {
            if (Players.Count < 2)
            {
                Players.Add(playerSocket);
            }
        }

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