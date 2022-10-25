using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class BoardCalculator
    {
        public static List<Point> GetPoints(float lengthX, float lengthZ, int numPoints)
        {
            var result = new List<Point>();

            //DBP -> Distance Between Points
            var DBPX = lengthX / numPoints;
            var DBPZ = lengthZ / numPoints;

            var xPoints = new List<float>();
            var zPoints = new List<float>();
            
            for (var i = 1; i <= numPoints; i++)
            {
                xPoints.Add(DBPX*i - DBPX/2 - lengthX/2);
                zPoints.Add(DBPZ*i - DBPZ/2 - lengthZ/2);
            }
            
            foreach (var zPoint in zPoints)
            {
                foreach (var xPoint in xPoints)
                {
                    result.Add(new Point(xPoint, zPoint));
                }
            }

            return result;
        }
    }

    public struct Point
    {
        public float X { get; set; }
        public float Z { get; set; }

        public Point(float xPoint, float zPoint)
        {
            X = xPoint;
            Z = zPoint;
        }
    }
}