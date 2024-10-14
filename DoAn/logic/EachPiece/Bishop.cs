using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Bishop : Pieces
    {
        public override PieceType type => PieceType.Bishop;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.NorthWest,
            Direction.SouthWest,
            Direction.SouthEast,
            Direction.NorthEast,

        };
        public Bishop(Player color)
        {
            Color = color;
        }
        public override Pieces copy()
        {
            Bishop copy = new Bishop(Color);
            copy.Move = Move;
            return copy;
        }

        public override IEnumerable<Base> Get(Position from, Board board)
        {
            return MovePostionInDirs(from, board, dirs).Select(to => new Normal(from, to));
        }
    }
}

