using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Knight : Pieces
    {
        public override PieceType type => PieceType.Knight;
        public override Player Color { get; }
        public Knight(Player color)
        {
            Color = color;
        }
        public override Pieces copy()
        {
            Knight copy = new Knight(Color);
            copy.Move = Move;
            return copy;
        }

        private static IEnumerable<Position> Potential(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.North, Direction.South})
            {
                foreach (Direction hDir in new Direction[] {Direction.West, Direction.East})
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePos(Position from,Board board)
        {
            return Potential(from).Where(pos => Board.Inside(pos)
                && (board.Empty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Base> Get(Position from, Board board)
        {
            return MovePos(from, board).Select(to => new Normal(from,to));
        }
    }
}
