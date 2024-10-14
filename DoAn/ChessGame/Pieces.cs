using System;

namespace ChessGame
{
    // Enum để định nghĩa màu sắc của quân cờ
    public enum Player
    {
        None,
        White,
        Black
    }

    // Lớp cơ sở cho tất cả các quân cờ
    public abstract class Pieces
    {
        public Player Color { get; }
        public Position Position { get; set; }

        protected Pieces(Player color, Position position)
        {
            Color = color;
            Position = position;
        }

        // Phương thức trừu tượng để kiểm tra xem quân cờ có thể di chuyển đến vị trí đó hay không
        public abstract bool CanMove(Position from, Position to, Board board);

        // Phương thức kiểm tra xem quân cờ có thể bắt vua đối thủ hay không
        public abstract bool CanCaptureKing(Position position, Board board);

        // Phương thức sao chép quân cờ
        public abstract Pieces Copy();
    }

    // Các lớp cụ thể cho từng quân cờ
    public class King : Pieces
    {
        public King(Player color) : base(color) { }

        public override bool CanMove(Position from, Position to, Board board)
        {
            // Kiểm tra di chuyển của vua
            return Math.Abs(from.Row - to.Row) <= 1 && Math.Abs(from.Column - to.Column) <= 1;
        }

        public override bool CanCaptureKing(Position position, Board board)
        {
            // Kiểm tra xem vua có thể bắt được không (thường là không, chỉ là ví dụ)
            return false;
        }

        public override Pieces Copy()
        {
            return new King(this.Color);
        }
    }

    public class Queen : Pieces
    {
        public Queen(Player color) : base(color) { }

        public override bool CanMove(Position from, Position to, Board board)
        {
            // Kiểm tra di chuyển của hậu
            return from.Row == to.Row || from.Column == to.Column || Math.Abs(from.Row - to.Row) == Math.Abs(from.Column - to.Column);
        }

        public override bool CanCaptureKing(Position position, Board board)
        {
            // Thêm logic cho việc bắt vua
            return false;
        }

        public override Pieces Copy()
        {
            return new Queen(this.Color);
        }
    }

    public class Rook : Pieces
    {
        public Rook(Player color) : base(color) { }

        public override bool CanMove(Position from, Position to, Board board)
        {
            return from.Row == to.Row || from.Column == to.Column;
        }

        public override bool CanCaptureKing(Position position, Board board)
        {
            return false;
        }

        public override Pieces Copy()
        {
            return new Rook(this.Color);
        }
    }

    public class Knight : Pieces
    {
        public Knight(Player color) : base(color) { }

        public override bool CanMove(Position from, Position to, Board board)
        {
            return (Math.Abs(from.Row - to.Row) == 2 && Math.Abs(from.Column - to.Column) == 1) ||
                   (Math.Abs(from.Row - to.Row) == 1 && Math.Abs(from.Column - to.Column) == 2);
        }

        public override bool CanCaptureKing(Position position, Board board)
        {
            return false;
        }

        public override Pieces Copy()
        {
            return new Knight(this.Color);
        }
    }

    public class Bishop : Pieces
    {
        public Bishop(Player color) : base(color) { }

        public override bool CanMove(Position from, Position to, Board board)
        {
            return Math.Abs(from.Row - to.Row) == Math.Abs(from.Column - to.Column);
        }

        public override bool CanCaptureKing(Position position, Board board)
        {
            return false;
        }

        public override Pieces Copy()
        {
            return new Bishop(this.Color);
        }
    }

    public class Pawn : Pieces
    {
        public Pawn(Player color, Position position) : base(color, position) { }

        public override bool CanMove(Position target, Board board)
        {
            // Logic di chuyển cho quân tốt
            int direction = Color == Player.White ? 1 : -1;
            if (target.Row == Position.Row + direction && target.Column == Position.Column && board.Empty(target))
            {
                return true; // Di chuyển thẳng
            }

            if (target.Row == Position.Row + direction &&
                (target.Column == Position.Column - 1 || target.Column == Position.Column + 1) &&
                !board.Empty(target) &&
                board[target].Color != Color)
            {
                return true; // Bắt quân cờ
            }

            return false; // Không di chuyển hợp lệ
        }

        public override bool CanCaptureKing(Position target, Board board)
        {
            // Logic để kiểm tra có thể bắt vua hay không
            return CanMove(target, board);
        }

        public override Pieces Copy()
        {
            return new Pawn(Color, Position);
        }
    }
}
