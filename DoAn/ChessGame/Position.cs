using System;
using System.Collections.Generic;

namespace ChessGame
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Player Color()
        {
            return (Row + Column) % 2 == 0 ? Player.White : Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        // Băm giá trị
        public override int GetHashCode()
        {
            return Row * 31 + Column;
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public static Position operator +(Position pos, Direction dir)
        {
            // Sửa tên thuộc tính từ Rowdelta và Columndelta thành RowDelta và ColumnDelta
            return new Position(pos.Row + dir.RowDelta, pos.Column + dir.ColumnDelta);
        }
    }
}
