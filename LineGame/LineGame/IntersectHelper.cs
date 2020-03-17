using System;
using System.Collections.Generic;
using System.Drawing;

namespace LineGame
{
    // SOURCES FOR THE HELPER METHODS ON THIS PAGE:
    // 1. doIntersect method (including onSegment and orientation):
    // https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
    // 2. FindIntersection method:
    // https://rosettacode.org/wiki/Find_the_intersection_of_two_lines
    // 3. DrawnAway method is my original code. This method is very narrow in scope, but
    // deals with specific game situations that the methods above do not cover (for additional
    // details, see my comments below and in the NoInvalidIntersect method in Rules.cs)
    public class IntersectHelper
    {
        // Given three colinear points p, q, r, the function checks if 
        // point q lies on line segment 'pr' 
        static Boolean onSegment(Point p, Point q, Point r)
        {
            if (q.x <= Math.Max(p.x, r.x) && q.x >= Math.Min(p.x, r.x) &&
                q.y <= Math.Max(p.y, r.y) && q.y >= Math.Min(p.y, r.y))
                return true;

            return false;
        }

        // To find orientation of ordered triplet (p, q, r). 
        // The function returns following values 
        // 0 --> p, q and r are colinear 
        // 1 --> Clockwise 
        // 2 --> Counterclockwise 
        static int orientation(Point p, Point q, Point r)
        {
            // See https://www.geeksforgeeks.org/orientation-3-ordered-points/ 
            // for details of below formula. 
            int val = (q.y - p.y) * (r.x - q.x) -
                    (q.x - p.x) * (r.y - q.y);

            if (val == 0) return 0; // colinear 

            return (val > 0) ? 1 : 2; // clock or counterclock wise 
        }

        // The main function that returns true if line segment 'p1q1' 
        // and 'p2q2' intersect. 
        public static Boolean doIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            // Find the four orientations needed for general and 
            // special cases 
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            // General case 
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases 
            // p1, q1 and p2 are colinear and p2 lies on segment p1q1 
            if (o1 == 0 && onSegment(p1, p2, q1)) return true;

            // p1, q1 and q2 are colinear and q2 lies on segment p1q1 
            if (o2 == 0 && onSegment(p1, q2, q1)) return true;

            // p2, q2 and p1 are colinear and p1 lies on segment p2q2 
            if (o3 == 0 && onSegment(p2, p1, q2)) return true;

            // p2, q2 and q1 are colinear and q1 lies on segment p2q2 
            if (o4 == 0 && onSegment(p2, q1, q2)) return true;

            return false; // Doesn't fall in any of the above cases 
        }
        public static PointF FindIntersection(PointF s1, PointF e1, PointF s2, PointF e2)
        {
            float a1 = e1.Y - s1.Y;
            float b1 = s1.X - e1.X;
            float c1 = a1 * s1.X + b1 * s1.Y;

            float a2 = e2.Y - s2.Y;
            float b2 = s2.X - e2.X;
            float c2 = a2 * s2.X + b2 * s2.Y;

            float delta = a1 * b2 - a2 * b1;
            //If lines are parallel, the result will be (NaN, NaN).
            return delta == 0 ? new PointF(float.NaN, float.NaN)
                : new PointF((b2 * c1 - b1 * c2) / delta, (a1 * c2 - a2 * c1) / delta);
        }
        // The DrawnAway method determines if two line segments with the same slope, beginning
        // at the same starting point, are drawn in different directtions or in the same direction.
        // It will only return a meaningful value if it is called on line segments with the same 
        // slope, but it is used precisely for these cases in the game
        public static bool drawnAway(Point start, Point endOne, Point endTwo)
        {
            if (start.x == endOne.x)
            {
                bool directionOne = (endOne.y - start.y) > 0;
                bool directionTwo = (endTwo.y - start.y) > 0;
                if (directionOne != directionTwo) return true;
                else return false;
            }
            else if (start.y == endOne.y)
            {
                bool directionOne = (endOne.x - start.x) > 0;
                bool directionTwo = (endTwo.x - start.x) > 0;
                if (directionOne != directionTwo) return true;
                else return false;
            }
            else
            {
                bool directionOneX = (endOne.x - start.x) > 0;
                bool directionTwoX = (endTwo.x - start.x) > 0;
                bool directionOneY = (endOne.x - start.x) > 0;
                bool directionTwoY = (endTwo.x - start.x) > 0;
                if (directionOneX != directionTwoX && directionOneY != directionTwoY) return true;
                else return false;
            }
        }
    }
}
