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
        public string RoomId { get; set; }
        public string Role { get; set; }
        public string BoardState { get; set; }
        public string Move { get; set; } // Thêm Move để lưu nước đi

        public Packet() { } // Constructor mặc định

        public Packet(string request, string message, string username, string nickname, string password, string email, string roomId = null, string role = null, string boardState = null, string move = null)
        {
            Request = request;
            Message = message;
            Username = username;
            Nickname = nickname;
            Password = password;
            Email = email;
            RoomId = roomId;
            Role = role;
            BoardState = boardState;
            Move = move;
        }

        // Serialize Packet to string
        public string ToPacketString()
        {
            return $"{EscapeSpecialChars(Request)}|{EscapeSpecialChars(Message)}|{EscapeSpecialChars(Username)}|{EscapeSpecialChars(Password)}|{EscapeSpecialChars(Email)}|{EscapeSpecialChars(Nickname)}|{EscapeSpecialChars(RoomId)}|{EscapeSpecialChars(Role)}|{EscapeSpecialChars(BoardState)}|{EscapeSpecialChars(Move)}";
        }

        // Deserialize string to Packet
        public static Packet FromPacketString(string packetString)
        {
            var parts = packetString.Split('|');
            if (parts.Length != 10)
            {
                throw new Exception("Invalid packet format.");
            }

            return new Packet(
                request: UnescapeSpecialChars(parts[0]),
                message: UnescapeSpecialChars(parts[1]),
                username: UnescapeSpecialChars(parts[2]),
                password: UnescapeSpecialChars(parts[3]),
                email: UnescapeSpecialChars(parts[4]),
                nickname: UnescapeSpecialChars(parts[5]),
                roomId: UnescapeSpecialChars(parts[6]),
                role: UnescapeSpecialChars(parts[7]),
                boardState: UnescapeSpecialChars(parts[8]),
                move: UnescapeSpecialChars(parts[9])
            );
        }

        private string EscapeSpecialChars(string str)
        {
            return str?.Replace("|", "||");
        }

        private static string UnescapeSpecialChars(string str)
        {
            return str?.Replace("||", "|");
        }
    }
}

