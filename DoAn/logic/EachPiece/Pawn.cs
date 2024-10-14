using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Pawn : Pieces
    {
        public override PieceType type => PieceType.Pawn;
        public override Player Color { get; }
        private readonly Direction forward;
        public Pawn(Player color)
        { 
            Color = color;
            if (color == Player.White)
            {
                forward = Direction.North;
            }
            else if (color == Player.Black)
            {
                forward = Direction.South;
            }
        }
        public override Pieces copy()
        {
            Pawn copy=new Pawn(Color);
            copy.Move = Move;
            return copy;
        }
        private static bool CanMoveTo(Position pos,Board board)
        {
            return Board.Inside(pos) && board.Empty(pos);
        }

        private bool CanCapture(Position pos, Board board)
        {
            if(!Board.Inside(pos) || board.Empty(pos))
            {
                return false;
            }
            return board[pos].Color != Color;
        }

        private static IEnumerable<Base> PromotionMove ( Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Queen);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
        }

        private IEnumerable<Base> ForwardMove(Position from, Board board)
        {
            Position onemove = from + forward;

            if(CanMoveTo(onemove, board))
            {
                if(onemove.Row == 0 || onemove.Row ==7)
                {
                    foreach(Base promMove in PromotionMove(from,onemove))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new Normal(from, onemove);
                }

                Position twoMove=onemove + forward;
                if(!Move && CanMoveTo(twoMove, board))
                {
                    yield return new Normal(from,twoMove);
                }
            }

        }
        private IEnumerable<Base> DiagonalMove(Position from, Board board) 
        { 
            foreach(Direction dir in new Direction[] {Direction.West, Direction.East})
            {
                Position to = from + forward + dir;

                if(CanCapture(to,board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Base promMove in PromotionMove(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new Normal(from, to);
                    }

                }
            }
        }
        public override IEnumerable<Base> Get (Position from, Board board)
        {
            return ForwardMove(from, board).Concat(DiagonalMove(from, board));
        }

        public override bool CanCaptureKing(Position from, Board board)
        {
            return DiagonalMove(from, board).Any(move =>
            {
                Pieces piece = board[move.To];
                return piece != null && piece.type == PieceType.King;
            });
        }
    }
}
