using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public  class Castling :Base
    {
        public override MoveType Type { get; }
        public override Position From { get; }
        public override Position To { get; }
        private readonly Direction KingMoveDir;
        private readonly Position rookFromPos;
        private readonly Position rookToPos;

        public Castling(MoveType type, Position kingPos)
        {
            Type = type;
            From = kingPos;

            if( type == MoveType.CastleK)
            {
                KingMoveDir = Direction.East;
                To = new Position(kingPos.Row, 6);
                rookFromPos = new Position(kingPos.Row, 7);
                rookToPos = new Position(kingPos.Row, 5);
            }
            else if( type == MoveType.CastleQ)
            { 
                KingMoveDir = Direction.West;
                To = new Position(kingPos.Row, 2);
                rookFromPos = new Position(kingPos.Row, 0);
                rookToPos = new Position(kingPos.Row, 3);
            }
        }

        public override void Execute(Board board)
        {
            new Normal(From, To).Execute(board);
            new Normal(rookFromPos, rookToPos).Execute(board);
        }

        public override bool IsLegal(Board board)
        {
            Player player = board[From].Color;
            if (board.IsInCheck(player))
            {
                return false;
            }
            Board copy = board.copy();
            Position kingPosInCopy = From;
            for(int i =0;i<2;i++)
            {
                new Normal(kingPosInCopy, kingPosInCopy + KingMoveDir).Execute(copy);
                kingPosInCopy += KingMoveDir;

                if(copy.IsInCheck(player))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
