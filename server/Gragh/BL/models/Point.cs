using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void ToPrintPoint()
        {
            Console.WriteLine("(" + this.X + ", " + this.Y + ")");
        }
        //חישוב נקודות מיוחדות לפונקציה
        public static List<Point> culc_points(Equation e)
        {
            List<Point> Points = new List<Point>();
            double a = 0;
            double b = 0;
            double c = 0;

            //משוואה עם שתי איברים מלאים
            if (e.Count == 2 && e.Class == 1)
            {
                double a1 = e.Parameters[0].Value * (e.Parameters[0].Operator == '-' ? -1 : 1);
                double b1 = e.Parameters[1].Value * (e.Parameters[1].Operator == '-' ? -1 : 1);
                double x = (-b1 / a1);
                Points.Add(new Point(x, 0));
                Points.Add(new Point(0, b1));
                return Points;
            }

            //משוואה עם שלושה איברים מלאים
            else if (e.Count == 3 && e.Class == 2)
            {
                a = e.Parameters[0].Value * (e.Parameters[0].Operator == '-' ? -1 : 1); //להכפיל באופרטור
                b = e.Parameters[1].Value * (e.Parameters[1].Operator == '-' ? -1 : 1);//להכפיל באופרטור
                c = e.Parameters[2].Value * (e.Parameters[2].Operator == '-' ? -1 : 1); //להכפיל באופרטור

            }

            //משוואה עם שתי איברים ממעלה שניה - a, b
            else if (e.Count == 2 && e.Class == 2 && e.Parameters[1].Class == 1)
            {
                a = e.Parameters[0].Value * (e.Parameters[0].Operator == '-' ? -1 : 1);
                b = e.Parameters[1].Value * (e.Parameters[1].Operator == '-' ? -1 : 1);
                c = 0;
            }

            //משוואה עם שתי איברים ממעלה שניה - a, c
            else if (e.Count == 2 && e.Class == 2 && e.Parameters[1].Class == 0)
            {
                a = e.Parameters[0].Value * (e.Parameters[0].Operator == '-' ? -1 : 1);
                b = 0;
                c = e.Parameters[1].Value * (e.Parameters[1].Operator == '-' ? -1 : 1);
            }

            //חישוב טרינום -נקודות חיתוך עם ציר האיקס
            double x1 = ((-b) + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            double x2 = ((-b) - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            Points.Add(new Point(x1, 0));
            Points.Add(new Point(x2, 0));


            double Ykodkod = 0;
            double Xkodkod = (-b) / (2 * a);

            if (c==0)
            {
                //חישוב קודקוד הפונקציה - נקודת קיצון
                Ykodkod = (a * Math.Pow(Xkodkod, e.Parameters[0].Class)
                + (b * Math.Pow(Xkodkod, e.Parameters[1].Class)));

                //חישוב נקודות עם ציר האיי
                double Yx = 0;
                double Yy = (a * Math.Pow(Yx, e.Parameters[0].Class)
                    + (b * Math.Pow(Yx, e.Parameters[1].Class)));
                Points.Add(new Point(Yx, Yy));
            }
            else if (b == 0)
            {
                //חישוב קודקוד הפונקציה - נקודת קיצון
                Ykodkod = (a * Math.Pow(Xkodkod, e.Parameters[0].Class)
                + (c * Math.Pow(Xkodkod, e.Parameters[1].Class)));

                //חישוב נקודות עם ציר האיי
                double Yx = 0;
                double Yy = (a * Math.Pow(Yx, e.Parameters[0].Class)
                + (c * Math.Pow(Yx, e.Parameters[1].Class)));
                Points.Add(new Point(Yx, Yy));
            }
            else
            {

                //חישוב קודקוד הפונקציה - נקודת קיצון
                Ykodkod = (a * Math.Pow(Xkodkod, e.Parameters[0].Class)
                + (b * Math.Pow(Xkodkod, e.Parameters[1].Class))
                + (c * Math.Pow(Xkodkod, e.Parameters[2].Class)));


                //חישוב נקודות עם ציר האיי
                double Yx = 0;
                double Yy = (a * Math.Pow(Yx, e.Parameters[0].Class)
                    + (b * Math.Pow(Yx, e.Parameters[1].Class))
                    + (c * Math.Pow(Yx, e.Parameters[2].Class)));
                Points.Add(new Point(Yx, Yy));
            }

            Console.WriteLine("kodkod");
            Points.Add(new Point(Xkodkod, Ykodkod));
            //Console.WriteLine("(" + Xkodkod + ", " + Ykodkod + ")");

            return Points;
        }


        //חישוב נגזרת הפונקציה
        public static Equation calc_nigzeret(Equation e)
        {

            Equation nigzeret = new Equation();
            nigzeret.Parameters = new List<Parameter>();

            int m = 0;

            foreach (var i in e.Parameters)
            {
                if (i.Class == 0) break;
                Parameter p = new Parameter();
                p.Value = i.Value * i.Class;
                p.Operator = i.Operator;
                p.Class = i.Class - 1;
                nigzeret.Parameters.Add(p);
                m++;
            }
            nigzeret.Class = nigzeret.Parameters[0].Class;
            nigzeret.Count = m;
            return nigzeret;
        }


        public static List<Point> culc_point_class_tree(Equation e)
        {


            List<Point> points = new List<Point>();






            return points;
        }


    }

}
