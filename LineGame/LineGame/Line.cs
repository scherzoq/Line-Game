using System;
using System.Collections.Generic;

namespace LineGame
{
    public class Line
    {
        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }
        public Point start { get; set; }
        public Point end { get; set; }
    }
}
