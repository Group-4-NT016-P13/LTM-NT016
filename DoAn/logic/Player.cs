using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    //enum cho chạy dễ hơn theo gg là v
    public enum Player
    {
        None,
        White,
        Black
    }

    public static class Playerextension
    {
        // dinh nghia doi thu
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None,
            };
        }
    }
}
