using System;
using System.Collections.Generic;

namespace LineGame
{
    public class Board
    {
        public Board()
        {
            // construct a 4 X 4 board
            const int size = 4;
            Points = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Point point = new Point(i, j);
                    Points.Add(point);
                }
            }
        }
        public List<Point> Points { get; set; }
    }
}
