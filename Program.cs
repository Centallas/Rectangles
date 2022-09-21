using System;
using System.Drawing;
using System.Linq;

namespace Rectangles
{
    class Program
    {

        static void Main(string[] args)
        {
            GetIntersection();
            GetIntersectionManual();

        }

        private static void GetIntersection()
        {
            // Example 1
            Rectangle rect1 = new Rectangle(0, 0, 4, 4);
            Rectangle rect2 = new Rectangle(2, 2, 3, 3);
            //Example 2
            // Rectangle rect1 = new Rectangle(0, 0, 2, 2);
            // Rectangle rect2 = new Rectangle(2, 0, 3, 1);
            var rectangleOutput = Rectangle.Intersect(rect1, rect2);
            Console.WriteLine("Rectangle intersection" + " " + rectangleOutput );
           
           
        }
        private static void GetIntersectionManual()
        {
            int[] rec1 = { 0, 0, 4, 4 };
            int[] rec2 = { 2, 2, 3, 3 };
            // int[] rec1 = { 0, 0, 2, 2 };
            // int[] rec2 = { 2, 0, 3, 1 };

            string[] result = rec1.Select(x => x.ToString()).ToArray();
            string[] result2 = rec2.Select(x => x.ToString()).ToArray();


            Console.WriteLine("Rectangle 1 - " + String.Join(",", result));
            Console.WriteLine("Rectangle 2 - " + String.Join(",", result2));

            //Boolean isOverlaping = isRectangleOverlap(rec1, rec2);
            var res = isRectangleOverlap(rec1, rec2);
            if (res.isOverlaping)
            {
                //Console.WriteLine(isOverlaping ? "The rectangles are overlapping" : "The rectangles are not overlapping");
                string[] widhtInters = res.WidthIntersects.Select(x => x.ToString()).ToArray();
                string[] heightInters = res.HeightIntersects.Select(x => x.ToString()).ToArray();               
                Console.WriteLine("Rectangle intersects - " + String.Join(",", widhtInters));
                Console.WriteLine("Rectangle intersects - " + String.Join(",", heightInters));
                 Console.WriteLine("The Rectagule is Overlaping!" + " "+ "Result is" + " " + res.isOverlaping );
            }else{
                Console.WriteLine("The Rectangles are Adjacent not Intersections between The Rectangles!"+ " " + res.isOverlaping);
            }
           

        }
        public static Result isRectangleOverlap(int[] rec1, int[] rec2)
        {

            //4      //3 -- Min √       //0       //2 -- Max √ 
            var widthIsPositive = Math.Min(rec1[2], rec2[2]) > Math.Max(rec1[0], rec2[0]);
            var heightIsPositive = Math.Min(rec1[3], rec2[3]) > Math.Max(rec1[1], rec2[1]);
            Result result = new Result();
            
            if (widthIsPositive && heightIsPositive)
            {   result.isOverlaping = true;            
                string[] widthIntersect = { "Width X", rec1[2].ToString(), rec2[2].ToString(), rec1[0].ToString(), rec2[0].ToString() };
                result.WidthIntersects = widthIntersect;
                string[] heightIntersect = { "Height Y", rec1[3].ToString(), rec2[3].ToString(), rec1[1].ToString(), rec2[1].ToString() };
                result.HeightIntersects = heightIntersect;
            }
            else{
                result.isOverlaping = false;
            }

            return result;

        }

    }
    class Result
    {
        public bool isOverlaping { get; set; }
        public string[] WidthIntersects { get; set; }
        public string[] HeightIntersects { get; set; }
    }


}
