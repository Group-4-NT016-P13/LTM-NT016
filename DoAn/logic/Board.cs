using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Board
    {
        private readonly Pieces[,] pieces = new Pieces[8, 8];
        //Chỉ mục(indexer) để truy cập 
        public Pieces this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Pieces this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public static Board initial()
        {
            Board board = new Board();
            board.AddstartPieces();
            return board;
        }

        private void AddstartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(Player.Black);
                this[6, i] = new Pawn(Player.White);
            }
        }
        // kiem tra vi tri
        public static bool Inside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 & pos.Column >= 0 && pos.Column < 8;
        }
        // kiem tra rong
        public bool Empty(Position pos)
        {
            return this[pos] == null;
        }

        public IEnumerable<Position> PiecePos()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Position pos = new Position(r, c);
                    if (!Empty(pos))
                    {
                        yield return pos;
                    }
                }
            }

        }
        public IEnumerable<Position> PiecePositionFor(Player player)
        {
            return PiecePos().Where(pos => this[pos].Color == player);
        }

        public bool IsInCheck(Player player)
        {
            return PiecePositionFor(player.Opponent()).Any(pos =>
            {
                Pieces piece = this[pos];
                return piece.CanCaptureKing(pos, this);
            });
        }

        public Board copy()
        {
            Board copy = new Board();
            foreach(Position pos in PiecePos())
            {
                copy[pos] = this[pos].copy();

            }
            return copy;
        }
    }
}
