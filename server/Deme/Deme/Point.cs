using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deme
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public static List<Point> Points { get; set; }=new List<Point>();
        

        public Point(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void ToString()
        {
            Console.WriteLine("("+this.X+", "+this.Y+")");
        }

        public static List<Point> culc_points(Equation e)
        {
            double a = Convert.ToDouble(e.Parameters[0].Value);
            double b = Convert.ToDouble(e.Parameters[1].Value);
            double c = Convert.ToDouble(e.Parameters[2].Value);
            Console.WriteLine();
            Console.WriteLine("print a, b, c");
            Console.WriteLine("a= " + a + "\nb= " + b + "\nc= " + c);
            Console.WriteLine();

            //חישוב טרינום -נקודות חיתוך עם ציר האיקס
            double x1 = ((-b) + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            double x2 = ((-b) - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            Points.Add(new Point(x1, 0));
            Points.Add(new Point(x2, 0));
            Console.WriteLine("print Cutting points");
            //Console.WriteLine("(" + x1 + ", 0)");
            //Console.WriteLine("(" + x2 + ", 0)");
            Console.WriteLine();

            //חישוב קודקוד הפונקציה - נקודת קיצון
            double Xkodkod = (-b) / (2 * a);
            double Ykodkod = (a * (Math.Pow(Xkodkod, Convert.ToInt32(e.Parameters[0].Class.ToString()))))
                + (b * (Math.Pow(Xkodkod, Convert.ToInt32(e.Parameters[1].Class.ToString()))))
                + (c * (Math.Pow(Xkodkod, Convert.ToInt32(e.Parameters[2].Class.ToString()))));
            Console.WriteLine("kodkod");
            Points.Add(new Point(Xkodkod, Ykodkod));
            //Console.WriteLine("(" + Xkodkod + ", " + Ykodkod + ")");

            //חישוב נגזרת הפונקציה
            string derivative = (a * (Convert.ToInt32(e.Parameters[0].Class.ToString()))).ToString();//נגזרת
            derivative = derivative += "x " + e.Parameters[1].Value;
            //Console.WriteLine("f(x) = " + strGraph);
            Console.WriteLine("f'(x) = " + derivative);
            Console.WriteLine();

            return Points;
        }


    }
}
