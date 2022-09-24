using System;
using System.Drawing;
using System.Linq;

namespace Rectangles
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] rec1, rec2;
            GetArrayData(out rec1, out rec2);

            Console.WriteLine("Rectange 1 - " + String.Join(",", rec1.Select(x => x.ToString()).ToArray()));
            Console.WriteLine("Rectange 2 - " + String.Join(",", rec2.Select(x => x.ToString()).ToArray()));
            Boolean isOverlapping = isRectangleOverlap(rec1, rec2);
            Console.WriteLine(isOverlapping ? "The rectangles are overlaping" : "The rectangles are not overlaping");

            GetIntersectionbyPoints(rec1, rec2);
        }

        private static void GetArrayData(out int[] r1, out int[] r2)
        {
            int[] rec1 = { 0, 0, 2, 2 };
            r1 = rec1;
            int[] rec2 = { 2, 0, 3, 1 };
            r2 = rec2;
            // rec1 = { 0, 0, 4, 4 };
            // rec2 = { 2, 2, 3, 3 };
        }

        public static Boolean isRectangleOverlap(int[] rec1, int[] rec2)
        {
            Boolean widthIsPositive = Math.Min(rec1[2], rec2[2]) > Math.Max(rec1[0], rec2[0]);
            Boolean heightIsPositive = Math.Min(rec1[3], rec2[3]) > Math.Max(rec1[1], rec2[1]);
            return (widthIsPositive && heightIsPositive);
        }



        public static void GetIntersectionbyPoints(int[]r1, int[]r2)
        {   
            //Rectangle 1        
            int x1 = r1[0], y1 = r1[1],
                x2 = r1[2], y2 = r1[3];
            //Rectangle 2        
            int x3 = r2[0], y3 = r2[1],
                x4 = r2[2], y4 = r2[3];

            // function call
            FindPoints(x1, y1, x2, y2,
                       x3, y3, x4, y4);

        }
        // function to find intersection
        // rectangle of given two rectangles.
        static void FindPoints(int x1, int y1,
                               int x2, int y2,
                               int x3, int y3,
                               int x4, int y4)
        {
            // gives bottom-left point
            // of intersection rectangle
            int x5 = Math.Max(x1, x3);
            int y5 = Math.Max(y1, y3);

            // gives top-right point
            // of intersection rectangle
            int x6 = Math.Min(x2, x4);
            int y6 = Math.Min(y2, y4);

            // no intersection
            if (x5 > x6 || y5 > y6)
            {
                Console.WriteLine("No intersection");
                return;
            }
            Console.WriteLine("Points of intersection are: ");

            Console.Write("(" + x5 + ", " +
                                y5 + ") ");

            Console.Write("(" + x6 + ", " +
                                y6 + ") ");

            // gives top-left point
            // of intersection rectangle
            int x7 = x5;
            int y7 = y6;

            Console.Write("(" + x7 + ", " +
                                y7 + ") ");

            // gives bottom-right point
            // of intersection rectangle
            int x8 = x6;
            int y8 = y5;

            Console.Write("(" + x8 + ", " +
                                y8 + ") ");
        }

    }

    class Result
    {
        public bool isOverlaping { get; set; }
        public string[] WidthIntersects { get; set; }
        public string[] HeightIntersects { get; set; }
    }


}
