using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class PawnPromotion : Base
    {
        public override MoveType Type => MoveType.PawnPromotion;
        public override Position From { get; }
        public override Position To { get; }

        private readonly PieceType newType;

        public PawnPromotion (Position from, Position to, PieceType newType)
        {
            From = from;
            To = to;
            this.newType = newType;
        }

        private Pieces CreatePromotionPiece(Player color)
        {
            return newType switch
            {
                PieceType.Knight => new Knight(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Rook => new Rook(color),
                _ => new Queen(color),
            };
        }

        public override void Execute(Board board)
        {
            Pieces pawn = board[From];
            board[From] = null;

            Pieces promotionPiece = CreatePromotionPiece(pawn.Color);
            promotionPiece.Move = true;
            board[To] = promotionPiece;
        }
    }
}
