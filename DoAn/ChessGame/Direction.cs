using System;
using System.Collections.Generic;

namespace ChessGame
{
    public class Direction
    {
        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   RowDelta == direction.RowDelta &&
                   ColumnDelta == direction.ColumnDelta;
        }

        public override int GetHashCode()
        {
            return (RowDelta * 397) ^ ColumnDelta;
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }

        // Một số ví dụ về các hướng di chuyển
        public static readonly Direction Up = new Direction(-1, 0);
        public static readonly Direction Down = new Direction(1, 0);
        public static readonly Direction Left = new Direction(0, -1);
        public static readonly Direction Right = new Direction(0, 1);
        public static readonly Direction UpLeft = new Direction(-1, -1);
        public static readonly Direction UpRight = new Direction(-1, 1);
        public static readonly Direction DownLeft = new Direction(1, -1);
        public static readonly Direction DownRight = new Direction(1, 1);
    }
}
