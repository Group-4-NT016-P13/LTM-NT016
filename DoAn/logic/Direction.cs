using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Direction
    {
        //set hướng
        public readonly static Direction North = new Direction(-1,0);
        public readonly static Direction South =new Direction(1,0);
        public readonly static Direction East = new Direction(0, 1);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction SouthWest = South + West;
        public readonly static Direction SouthEast = South + East;
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;

        public int Rowdelta { get; }
        public int Columndelta { get; }
        public Direction(int rowdelta, int columndelta)
        {
            Rowdelta = rowdelta;
            Columndelta = columndelta;
        }
        // set toán tử
        public static Direction operator + (Direction dril1, Direction dril2)
        {
            return new Direction(dril1.Rowdelta + dril2.Rowdelta, dril1.Columndelta + dril2.Columndelta);

        }
        
        public static Direction operator*(int scalar,Direction dir)
        {
            return new Direction(scalar * dir.Rowdelta, scalar * dir.Columndelta);
        }
    }
}
