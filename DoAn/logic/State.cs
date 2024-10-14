using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace logic
{
    public class State
    {
        public Board Board { get; }
        public Player playing { get; private set; }
        public Result result { get; private set; } = null;

        public State(Player player, Board board)
        {
            playing = player;
            Board = board;
        }
        public  IEnumerable<Base> LegalMove( Position pos)
        {
            if(Board.Empty(pos) || Board[pos].Color!= playing)
            {
                return Enumerable.Empty<Base>();
            }

            Pieces pieces = Board[pos];
            IEnumerable<Base> MoveCandidate = pieces.Get(pos, Board);
            return MoveCandidate.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Base move)
        {
            move.Execute(Board);
            playing = playing.Opponent();
            Checkgameover();
        }

        public IEnumerable<Base> AllLegalMoveFor(Player player)
        {
            IEnumerable<Base> moveCandidates = Board.PiecePositionFor(player).SelectMany(pos =>
            {
                Pieces piece = Board[pos];
                return piece.Get(pos, Board);
            });

            return moveCandidates.Where(move => move.IsLegal(Board));   

        }

        private void Checkgameover()
        {
            if(!AllLegalMoveFor(playing).Any())
            {
                if(Board.IsInCheck(playing))
                {
                    result = Result.Win(playing.Opponent());
                }
                else
                {
                    result = Result.Draw(EndReason.stalemate);
                }
            }
        }

        public bool IsGameOver()
        {
            return result != null;
        }
    }
}
