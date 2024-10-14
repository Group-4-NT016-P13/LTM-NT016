using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Queen : Pieces
    {
        public override PieceType type => PieceType.Queen;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
       {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthWest,
            Direction.SouthWest,
            Direction.SouthEast,
            Direction.NorthEast

       };
        public Queen(Player color)
        {
            Color = color;
        }
        public override Pieces copy()
        {
            Queen copy = new Queen(Color);
            copy.Move = Move;
            return copy;
        }

        public override IEnumerable<Base> Get(Position from, Board board)
        {
            return MovePostionInDirs(from, board, dirs).Select(to => new Normal(from, to));
        }
    }
}

