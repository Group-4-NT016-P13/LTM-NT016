using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chess
{
    public enum ChessColor { WHITE, BLACK, NONE }
    public partial class Tile : UserControl
    {
        public ChessPiece piece = new ChessPiece(PieceKind.EMPTY); //EMPTY piece
        public ChessColor color = ChessColor.WHITE;
        public Location location = new Location();
        public ChessColor tileAttack = ChessColor.NONE;
        public void SetAttack(ChessPiece pieceAttack) { tileAttack = pieceAttack.color; }
        public void RemoveAttack() { tileAttack = ChessColor.NONE; }
        public void PrintTileInfo()
        {
            Debug.Print("Y:" + GetY + " X:" + GetX + " TileAttack:" + tileAttack.ToString());
        }
        public byte GetY { get { return location.y; } }
        public byte GetX { get { return location.x; } }
        public bool isOccupied() => piece.piecekind != PieceKind.EMPTY;
        public Tile(byte y, byte x) { InitializeComponent(); location.y = y; location.x = x; Location = new Point(x * Size.Width, y * Size.Height); }
        public Tile(byte y, byte x, ChessColor color) : this(y, x) { this.color = color; }
        public Color TileColor() => color != ChessColor.WHITE ? Color.Gray : Color.LightGray;
        public void PieceAssign(ChessPiece piece)
        {
            this.piece = piece;
            PieceImage.BackgroundImage = PieceImages[piece.ImageName()];
        }
        private void Tile_Load(object sender, EventArgs e)
        {
            this.PieceImage.BackColor = TileColor();
            this.BackColor = TileColor();
            this.Click += TileClicked;
            this.PieceImage.Click += TileClicked;
        }
        static int click = 0;
        static Movement piecemoves;
        public void PossibleMove(bool show)
        {
            if (!show) PieceImage.Image = null;
            else PieceImage.Image = Properties.Resources.Possible;
        }
        private void TileClicked(object sender, EventArgs e)
        {
            if (click == 0 && this.piece.color != Board.CurrentPlayer) return;
            click++;
            if (click == 1)
            {
                piecemoves = new Movement(this);
                piecemoves.IsKingSafe();
                piecemoves.MovesInterface(true);
            }
            else
            {
                piecemoves.isAvailableMove(this);
                click = 0;
            }
        }
        public static Dictionary<string, Image> PieceImages = new Dictionary<string, Image> {
            { "BBishop",Properties.Resources.BBishop},
            { "BKnight",Properties.Resources.BKnight },
            { "BRook",Properties.Resources.BRook },
            { "BKing",Properties.Resources.BKing },
            { "BQueen",Properties.Resources.BQueen },
            { "BPawn",Properties.Resources.BPawn },
            { "WBishop",Properties.Resources.WBishop },
            { "WKnight",Properties.Resources.WKnight },
            { "WRook",Properties.Resources.WRook },
            { "WKing",Properties.Resources.WKing},
            { "WQueen",Properties.Resources.WQueen },
            { "WPawn",Properties.Resources.WPawn },
            { "EMPTY",null }
        };
    }
    public struct Location
    {
        public byte y, x;
    }
}