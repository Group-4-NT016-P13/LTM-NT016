using System;

namespace TCPServer
{
    public class Packet
    {
        public string Request { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string RoomId { get; set; }
        public string Role { get; set; } // Add Role property
        public string BoardState { get; set; } // Add BoardState property

        public Packet(string request, string message, string username, string nickname, string password, string email, string roomId = null, string boardState = null)
        {
            Request = request;
            Message = message;
            Username = username;
            Nickname = nickname;
            Email = email;
            Password = password;
            RoomId = roomId; // Initialize RoomId if provided
            BoardState = boardState; // Initialize BoardState if provided
        }

        public string ToPacketString()
        {
            return $"{Request}|{EscapeSpecialChars(Message)}|{EscapeSpecialChars(Username)}|{EscapeSpecialChars(Password)}|{EscapeSpecialChars(Email)}|{EscapeSpecialChars(Nickname)}|{EscapeSpecialChars(RoomId)}|{EscapeSpecialChars(BoardState)}"; // Include BoardState
        }

        public static Packet FromPacketString(string packetString)
        {
            var parts = packetString.Split('|');
            if (parts.Length != 8) // Adjust the length check for the new BoardState
            {
                throw new Exception("Invalid packet format.");
            }

            return new Packet(
                request: parts[0],
                message: UnescapeSpecialChars(parts[1]),
                username: UnescapeSpecialChars(parts[2]),
                password: UnescapeSpecialChars(parts[3]),
                email: UnescapeSpecialChars(parts[4]),
                nickname: UnescapeSpecialChars(parts[5]),
                roomId: UnescapeSpecialChars(parts[6]), // Deserialize RoomId
                boardState: UnescapeSpecialChars(parts[7]) // Deserialize BoardState
            );
        }

        private string EscapeSpecialChars(string str)
        {
            return str.Replace("|", "||");
        }

        private static string UnescapeSpecialChars(string str)
        {
            return str.Replace("||", "|");
        }
    }
}
