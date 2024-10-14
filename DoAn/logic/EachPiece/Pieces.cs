using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    // truu tuong de overide
    public abstract class Pieces
    {
        public abstract PieceType type { get; }
        public abstract Player Color { get; }
        public bool Move { get; set; } = false;
        public abstract Pieces copy(); 

        public abstract IEnumerable<Base> Get(Position from, Board board);
        protected IEnumerable<Position> MovePostionInDir(Position from, Board board,Direction dir)
        {
            for (Position pos = from + dir; Board.Inside(pos); pos += dir)
            {
                if(board.Empty(pos))
                {
                    yield return pos;
                    continue;
                }
                Pieces piece = board[pos];
                if(piece.Color != Color)
                {
                    yield return pos;
                }
                yield break;
            }
        }

        protected IEnumerable<Position> MovePostionInDirs(Position from, Board board,Direction[] dirs)
        {
            return dirs.SelectMany(dir => MovePostionInDir(from, board,dir));
        }
        public virtual bool CanCaptureKing(Position from , Board board)
        {
            return Get(from, board).Any(move =>
            {
                Pieces piece = board[move.To];
                return piece != null && piece.type == PieceType.King;
            });
        }
    }
}
