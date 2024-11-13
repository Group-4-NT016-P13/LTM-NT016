using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Packet
    {
        public string Request { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string GameId { get; set; }
        public string BasePos { get; set; }
        public string EndPos { get; set; }

        // Các thuộc tính mới cho việc tạo phòng
        public string Player1Color { get; set; }
        public string Player2Color { get; set; }
        public string Player1Nickname { get; set; }
        public string Player2Nickname { get; set; }

        // Các thuộc tính cho nước đi của người chơi
        public string Move { get; set; }
        public Packet(string request, string message, string username, string nickname, string password, string email)
        {
            Request = request;
            Message = message;
            Username = username;
            Nickname = nickname;
            Email = email;
            Password = password;
        }
        public Packet(string request, string message, string gameId, string player1Nickname, string player2Nickname, string player1Color, string player2Color, string move)
        {
            Request = request;
            Message = message;
            GameId = gameId;
            Player1Nickname = player1Nickname;
            Player2Nickname = player2Nickname;
            Player1Color = player1Color;
            Player2Color = player2Color;
            Move = move;
        }


        // ToPacketString để gửi thông tin đăng ký người chơi
        public string ToPacketString()
        {
            return $"{Request}|{Message}|{Username}|{Password}|{Email}|{Nickname}";
        }

        // ToPacketString cho tạo phòng game
        public string ToPacketRoomString()
        {
            return $"{Request}|{Message}|{GameId}|{Player1Nickname}|{Player2Nickname}|{Player1Color}|{Player2Color}";
        }

        public static Packet FromPacketString(string packetString)
        {
            var parts = packetString.Split('|');
            return new Packet(
                request: parts[0],
                message: parts[1],
                username: parts[2],
                password: parts[3],
                email: parts[4],
                nickname: parts[5]
            );
        }

        public static Packet FromPacketRoomString(string packetString)
        {
            var parts = packetString.Split('|');
            return new Packet(
                request: parts[0],
                message: parts[1],
                gameId: parts[2],
                player1Nickname: parts[3],
                player2Nickname: parts[4],
                player1Color: parts[5],
                player2Color: parts[6],
                move: parts[7]
            );
        }
    }
}

