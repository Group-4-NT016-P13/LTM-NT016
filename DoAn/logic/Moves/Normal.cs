using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Normal : Base
    {
        public override MoveType Type => MoveType.Normal;
        public override Position From { get; }
        public override Position To { get; }
        public Normal(Position form, Position to)
        {
            From = form;
            To = to;
        }

        public override void Execute(Board board)
        {
            Pieces pieces = board[From];
            board[To]= pieces;
            board[From] = null;
            pieces.Move = true;
        }
    }
}
