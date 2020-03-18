using System;
using System.Collections.Generic;
using System.Drawing;

namespace LineGame
{
    public class Rules
    {
        public static bool IsOctilinear(Point start, Point end)
        {
            if ((start.x == end.x || start.y == end.y || Math.Abs(start.x - end.x) == Math.Abs(start.y - end.y)) && (!(start.x == end.x && start.y == end.y)))
            {            
                return true;
            }
            else
            {
                return false;
            }
        }

        // returns true so long as new line does not violate game's line intersection rules
        public static bool NoInvalidIntersect(Line tryLine, List<Line> existingLines)
        {
            // check each existing line segment for intersection with new line segment
            foreach (Line line in existingLines)
            {   
                bool doesIntersect = IntersectHelper.doIntersect(tryLine.start, tryLine.end, line.start, line.end);
                // if there is an intersection , check if the intersection is at the start point of the new line
                // segment, since this intersection is OK. Note: the FindIntersection method only works on lines
                // which have a different slope. Additional logic is needed for line segments with the same slope      
                if (doesIntersect)
                {
                    
                    Func<float, float, PointF> p = (x, y) => new PointF(x, y);
                    PointF intersect = IntersectHelper.FindIntersection(p((float)tryLine.start.x, (float)tryLine.start.y), p((float)tryLine.end.x, (float)tryLine.end.y), p((float)line.start.x, (float)line.start.y), p((float)line.end.x, (float)line.end.y));
                    if (intersect.X == (float)tryLine.start.x && intersect.Y == (float)tryLine.start.y)
                    {
                        continue;
                    }
                    // additional logic for when line segment has same slope as the line segment that it
                    // intersects with; need to determine if the new line segment is drawn away from or
                    // toward the existing line segment
                    else if (double.IsNaN(intersect.X))
                    {
                        Point intersectPoint = new Point(tryLine.start.x, tryLine.start.y);
                        Point tryLineEndPoint = new Point(tryLine.end.x, tryLine.end.y);
                        Point existingLineEndPoint = new Point(0, 0);
                        if (line.start.x == intersectPoint.x && line.start.y == intersectPoint.y)
                        {
                            existingLineEndPoint.x = line.end.x;
                            existingLineEndPoint.y = line.end.y;
                        }
                        else
                        {
                            existingLineEndPoint.x = line.start.x;
                            existingLineEndPoint.y = line.start.y;
                        }
                        bool newLineDrawnAway = IntersectHelper.drawnAway(intersectPoint, tryLineEndPoint, existingLineEndPoint);
                        if (newLineDrawnAway == true)
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;        
        }

        // returns true if no valid moves remain on the board
        public static bool BoardComplete(Board board, List<Line> existingLines, List<Point> validStartNodes)
        {
            foreach (Point startNode in validStartNodes)
            {
                foreach (Point point in board.Points)
                {
                    Line tryLine = new Line(startNode, point);
                    bool octilinear = IsOctilinear(startNode, point);
                    bool noInvalidIntersect = NoInvalidIntersect(tryLine, existingLines);
                    if (octilinear && noInvalidIntersect)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
