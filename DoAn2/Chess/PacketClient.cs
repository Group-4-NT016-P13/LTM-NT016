using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
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


        public Packet(string request, string message,string username, string nickname, string password, string email)
        {
            Request = request;
            Message = message;
            Username = username;
            Nickname = nickname;
            Email = email;
            Password = password;
        }
        public Packet(string request,string message,string roomid,string nickname)
        {
            Request = request;
            Message = message;
            GameId = roomid;
            Nickname = nickname;
        }

        public string ToPacketString()
        {
            return $"{Request}|{Message}|{Username}|{Password}|{Email}|{Nickname}";
        }

        public string ToPacketRoomString()
        {
            return $"{Request}|{Message}|{GameId}|{Nickname}";
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
                roomid: parts[2],
                nickname: parts[3]
            );
        }
    }
}

