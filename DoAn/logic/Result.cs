﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Result
    {
        public Player Winner { get; }
        public EndReason reason { get; }
        public Result(Player winner, EndReason reason)
        {
            Winner = winner;
            this.reason = reason;
        }
        public static Result Win(Player winner)
        {
            return new Result(winner,EndReason.checkmate);
        }
        public static Result Draw(EndReason reason)
        {
            return new Result(Player.None, reason);
        }
    }
}
