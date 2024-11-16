using System;
using System.IO;
namespace Client
{
    public class MovePacket
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public MovePacket(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        // Chuyển đổi MovePacket thành mảng byte 
        public byte[] ToByteArray()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                // Ghi vị trí bắt đầu và kết thúc
                writer.Write(StartX);
                writer.Write(StartY);
                writer.Write(EndX);
                writer.Write(EndY);

                return stream.ToArray();
            }
        }

        // Chuyển đổi mảng byte thành MovePacket 
        public static MovePacket FromByteArray(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            using (var reader = new BinaryReader(stream))
            {
                // Đọc vị trí bắt đầu và kết thúc
                int startX = reader.ReadInt32();
                int startY = reader.ReadInt32();
                int endX = reader.ReadInt32();
                int endY = reader.ReadInt32();

                return new MovePacket(startX, startY, endX, endY);
            }
        }
    }
}
