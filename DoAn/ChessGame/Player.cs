using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    // Enum cho các màu quân cờ, đã đổi tên thành ChessPlayer
    public enum ChessPlayer
    {
        None,
        White,
        Black
    }

    public static class PlayerExtension
    {
        public static ChessPlayer Opponent(this ChessPlayer player)
        {
            //if (player == ChessPlayer.White)
            //{
            //    return ChessPlayer.Black;
            //}
            //else if (player == ChessPlayer.Black)
            //{
            //    return ChessPlayer.White;
            //}
            //else
            //{
            //    return ChessPlayer.None;
            //}
            switch (player)
            {
                case ChessPlayer.White:
                    return ChessPlayer.Black;
                case ChessPlayer.Black:
                    return ChessPlayer.White;
                default:
                    return ChessPlayer.None;
            };
        }

        // Kiểm tra màu của quân cờ
        public static bool IsWhite(this ChessPlayer player)
        {
            return player == ChessPlayer.White;
        }

        public static bool IsBlack(this ChessPlayer player)
        {
            return player == ChessPlayer.Black;
        }
    }
}

