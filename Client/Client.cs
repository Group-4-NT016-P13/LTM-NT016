using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public class Client
    {
        public static Socket clientSocket;
        public static Thread recvThread;

        public static void Connect(IPEndPoint serverEP)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(serverEP);
                recvThread = new Thread(ReceiveData);
                recvThread.IsBackground = true;
                recvThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kết nối server: " + ex.Message);
            }
        }

        public static void SendData( )
        {
            try
            {
             //   byte[] buffer = packet.ToBytes();
             //   clientSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }
        private static void ReceiveData()
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (clientSocket.Connected)
                {
                    // Nhận dữ liệu từ server
                    int receivedBytes = clientSocket.Receive(buffer);
                    if (receivedBytes > 0)
                    {
                        // Chuyển đổi dữ liệu nhận được thành chuỗi
                        string msg = Encoding.UTF8.GetString(buffer, 0, receivedBytes);


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi nhận dữ liệu từ server: " + ex.Message);
            }
            finally
            {
                clientSocket.Close();
                Console.WriteLine("Đã ngắt kết nối với server");
            }
        }

        //private static Packet ParsePacket(string msg)
        //{
        //    string[] payload = msg.Split(';');
        //    if (payload.Length == 0)
        //    {
        //        return null; // Không có dữ liệu
        //    }

            // Xác định loại packet dựa trên phần tử đầu tiên
        //    PacketType packetType;
        //    if (Enum.TryParse(payload[0], out packetType))
        //    {
        //        switch (packetType)
        //        {
        //            case PacketType.LOGIN_RESULT:
        //                return new LoginResultPacket(msg);
        //            case PacketType.REGISTER_RESULT:
        //                return new RegisterResultPacket(msg);
        //            case PacketType.ROOM_INFO:
        //                return new RoomInfoPacket(msg);
        //            case PacketType.OTHER_INFO:
        //                return new OtherInfoPacket(msg);
        //            case PacketType.ROUND_UPDATE:
        //                return new RoundUpdatePacket(msg);
        //            case PacketType.GUESS_RESULT:
        //                return new GuessResultPacket(msg);
        //            case PacketType.LEADER_BOARD_INFO:
        //                return new LeaderBoardInfoPacket(msg);
        //            default:
        //                return null; // Không biết loại packet
        //        }
        //    }
        //    return null;
        //}

        //private static void AnalyzingPacket(Packet packet)
        //{
        //    switch (packet.Type)
        //    {
        //        case PacketType.LOGIN_RESULT:
        //            break;
        //        case PacketType.REGISTER_RESULT:
        //            break;
        //        case PacketType.ROOM_INFO:
        //            break;
        //        case PacketType.OTHER_INFO:
        //            break;
        //        case PacketType.ROUND_UPDATE:
        //            break;
        //        case PacketType.GUESS_RESULT:
        //            break;
        //        case PacketType.LEADER_BOARD_INFO:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
