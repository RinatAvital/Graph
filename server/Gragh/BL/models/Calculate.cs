using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class Calculate
    {
        public static List<Point> Advancedculc_parameters(string str)
        {
            string strCopy = str;
            string strGraph = string.Join(" ", strCopy
               .Replace(" ", "") // remove all spaces because they kind of random now
               .Replace("+", " +") // add space to signs to keep them with their value
               .Replace("-", " -")
               .Split(' '));

            string[] s = strGraph.Split(' ');
            //בדיקת כמות האיברים בפונקציה
            int count = strGraph.Count(f => f == ' ') + 1;


            Equation equation = new Equation();
            equation.Parameters = new List<Parameter>();

            for (int i = 0; i < s.Length && s.Length != 0; i++)
            {
                Parameter p = new Parameter();
                //בדיקת מעלת הפרמטר
                switch (s[i][s[i].Length - 1])
                {
                    case 'x':
                        {
                            p.Class = 1;
                            break;
                        }
                    default:
                        {
                            if (s[i][s[i].Length - 2] == '^')//להגביל מעלה גבוהה
                            {
                                p.Class = Convert.ToInt32(s[i][s[i].Length - 1]) - 48;
                            }
                            else
                                p.Class = 0;

                            break;
                        }
                }
                calcOperator(p, s[i]);
                equation.Parameters.Add(p);

            }
            equation.Parameters = equation.Parameters.OrderByDescending(c => c.Class).ToList();
            equation.Class = equation.Parameters.Max(m => m.Class);
            equation.Count = count;
            return print(equation);
        }

        public static void calcOperator(Parameter p, string v)
        {
            p.Operator = '+';
            if (v[0] == '-')
                p.Operator = '-';
            string s = v.Split('+', '-', '^', 'x').OrderByDescending(x => x.Length).ToArray()[0];
            p.Value = Convert.ToDouble(s);


        }

        public static List<Point> print(Equation e)
        {

            Console.WriteLine(e.Class + " class");
            Console.WriteLine("mis evarim " + e.Count);
            foreach (var p in e.Parameters)
            {
                Console.WriteLine(p.Value + ", " + p.Operator + ", " + p.Class);
            }

            Console.WriteLine();
            List<Point> points = Point.culc_points(e);
            foreach (var p in points)
            {
                p.ToPrintPoint();
            }
            return points;
        }
    }
}
