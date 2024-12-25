using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace chess
{
    public class TCPClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        public event Action<bool> MatchFound;
        public string PieceColor;
        public string RoomID;
        public int Rating = 1200;
        public string Username = "null";
        public string Password = "null";
        public string Email = "null";
        public int UserId { get; private set; }
        public int Rank { get; private set; }

        public TCPClient(string serverIP, int serverPort)
        {
            tcpClient = new TcpClient();
            ConnectToServer(serverIP, serverPort).Wait();
        }

        private async Task ConnectToServer(string serverIP, int serverPort)
        {
            try
            {
                await tcpClient.ConnectAsync(IPAddress.Parse(serverIP), serverPort);
                stream = tcpClient.GetStream();
                Console.WriteLine("Connected to the server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }
        }

        public async Task<string> RegisterAsync(string username, string password, string email)
        {
            string request = $"REGISTER {username} {password} {email}";
            return await SendRequest(request);
        }

        public async Task<string> Logout(string username)
        {
            string request = $"LOGOUT {username}";
            return await SendRequest(request);
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            string request = $"LOGIN {username} {password}";
            return await SendRequest(request);
        }

        public async Task<string> CheckMailAsync(string email)
        {
            string request = $"CHECK {email}";
            return await SendRequest(request);
        }

        public async Task<string> UpdatePassword(string password,string email)
        {
            string request = $"UPDATEPASSWORD {password} {email}";
            return await SendRequest(request);
        }

        public async Task<string> UpdateRating(string username)
        {
            string request = $"UPDATE {username}";
            return await SendRequest(request);
        }

        public async Task<string> CreateRoom(string roomid, string hostcolor, string time)
        {
            string request = $"CREATEROOM {roomid} {hostcolor} {time}";
            return await SendRequest(request);
        }

        public async Task<string> FindRoom(string roomid)
        {
            string request = $"FINDROOM {roomid}";
            return await SendRequest(request);
        }
        public async Task<string> FindMatch()
        {
            string response = await SendRequest("FIND_MATCH");
            return response;
        }

        public async Task SendMove(string from, string to)
        {
            string message = $"MOVE {from} {to}";
            await SendMessageToServer(message);
        }

        public async Task<string> GameOver(string roomid, string result,string username)
        {
            string request = $"GAMEOVER {roomid} {result} {username}";
            return await SendRequest(request);
        }
        //dùng để gửi các nước đi k cần phản hồi
        private async Task SendMessageToServer(string message)
        {
            try
            {
                if (!tcpClient.Connected)
                {
                    throw new InvalidOperationException("Client chua ket noi voi server");
                }

                byte[] data = Encoding.UTF8.GetBytes(message + "\n"); // Thêm ký tự xuống dòng để đánh dấu kết thúc tin nhắn
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync(); // Đảm bảo dữ liệu được gửi ngay lập tức
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi gui tin nhan den server: {ex.Message}");
            }
        }
        //gửi tin nhắn
        public async Task SendMessage(string message)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }
        //gửi các yêu cầu cần phản hồi
        public async Task<string> SendRequest(string request)
        {
            try
            {
                if (!tcpClient.Connected)
                {
                    throw new InvalidOperationException("Client chua ket noi voi server");
                }

                byte[] data = Encoding.UTF8.GetBytes(request + "\n");
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();

                return await ReceiveResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"loi gui yeu cau: {ex.Message}");
                return "ERROR";
            }
        }

        public async Task<string> ReceiveResponse()
        {
            try
            {
                byte[] buffer = new byte[2048];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"loi nhan phan hoi: {ex.Message}");
                return "ERROR" + ex.Message;
            }
        }
        public void Close()
        {
            stream?.Close();
            tcpClient?.Close();
            Console.WriteLine("Disconnected from server.");
        }
    }
}