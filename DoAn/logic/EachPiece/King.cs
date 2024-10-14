using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class King : Pieces
    {
        public override PieceType type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.North,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.NorthWest,
            Direction.SouthWest
        };
        public King(Player color)
        {
            Color = color;
        }
        
        private static bool IsUnmoedRook(Position pos, Board board)
        {
            if (board.Empty(pos))
            {
                return false;
            }
            Pieces piece = board[pos];
            return piece.type == PieceType.Rook && !piece.Move;
        }
        private static bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos => board.Empty(pos));
        }

        private bool CanCastleKingSide(Position from, Board board)
        {
            if(Move)
            {
                return false;
            }
            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPosition = new Position[] { new(from.Row, 5), new(from.Row, 6) }; 
            return IsUnmoedRook(rookPos, board) && AllEmpty(betweenPosition, board);
        }

        private bool CanCastleQueenSide(Position from, Board board)
        {

            if (Move)
            {
                return false;
            }
            Position rookPos = new Position(from.Row, 0);
            Position[] betweenPosition = new Position[] { new(from.Row, 1), new(from.Row, 2), new(from.Row,3) };
            return IsUnmoedRook(rookPos, board) && AllEmpty(betweenPosition, board);
        }
        public override Pieces copy()
        {
            King copy = new King(Color);
            copy.Move = Move;
            return copy;
        }

        private IEnumerable<Position> MovePos(Position from, Board board)
        {
            foreach ( Direction dir in dirs)
            {
                Position to= from+ dir;
                if(!Board.Inside(to))
                {
                    continue;
                }
                if(board.Empty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override IEnumerable<Base> Get(Position from , Board board)
        {
            foreach ( Position to in MovePos(from,board))
            {
                yield return new Normal(from, to);
            }

            if(CanCastleKingSide(from, board))
            {
                yield return new Castling(MoveType.CastleK, from);
            }
            if (CanCastleQueenSide(from, board))
            {
                yield return new Castling(MoveType.CastleQ, from);
            }
        }

        public override bool CanCaptureKing(Position from, Board board)
        {
            return MovePos(from, board).Any(to =>
            {
                Pieces piece = board[to];
                return piece != null && piece.type == PieceType.King;
            });
        }
    }
}
