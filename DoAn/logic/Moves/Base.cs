using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public abstract class Base
    {
        public abstract MoveType Type { get; }
        public abstract Position From { get; }
        public abstract Position To { get; }
        public abstract void Execute(Board board);

        public virtual bool IsLegal(Board board)
        {
            Player player = board[From].Color;
            Board boardcopy = board.copy();
            Execute(boardcopy);
            return !boardcopy.IsInCheck(player);
        }
    }
}
