using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deme
{
    public class Program
    {
        public static void Main()
        {
           



            string str = "x^2-9";
            //    string strCopy = str;

            //    if (str.Length != 0 && str[0] != '-') // covers case when first member is positive, if it is not enough you can use str.TrimStart()[0]
            //    {
            //        strCopy = "+" + str;
            //    }
            //    string strGraph = string.Join(" ", strCopy
            //        .Replace(" ", "") // remove all spaces because they kind of random now
            //        .Replace("+", " +") // add space to signs to keep them with their value
            //        .Replace("-", " -")
            //        .Split(' '));
            //    strGraph = strGraph.Remove(0,1);//מוחק את הרווח הראשון 
            //    strGraph = strGraph.Insert(strGraph.Length, "  ");
            //    //בדיקת כמות האיברים בפונקציה
            //    int count = strGraph.Count(f => f == ' ')-1;

            //    for (int i = 0; i < count; i++)
            //    {
            //        equations[i] = new Parameter();
            //    }

            //    Console.WriteLine(count);



            //    //int s= strGraph.IndexOf(" ");

            //    int indexE = 0;
            //    for (int i = 0; i < strGraph.Length-3; i++)
            //    { 
            //        switch (strGraph[i])
            //        {
            //            case '+':
            //            {
            //                equations[indexE].Operator = '+'; i++;
            //                if (strGraph[i] == 'x')
            //                {
            //                    equations[indexE].Value = "1";
            //                }
            //                while (strGraph[i]!='x'&& strGraph[i] != '^'&& strGraph[i]!=' ')
            //                    equations[indexE].Value += strGraph[i++];

            //                if (strGraph[i] == 'x')
            //                {
            //                    if (strGraph[i + 1] == '^')
            //                    {
            //                        equations[indexE].Class = strGraph[i + 2];
            //                        i += 3;
            //                    }
            //                    else
            //                    {
            //                        equations[indexE].Class = '1';
            //                        i++;
            //                    }      
            //                }
            //                else
            //                {
            //                    equations[indexE].Class = '0';
            //                }
            //                indexE++;
            //            }
            //            break;
            //            case '-':
            //            {
            //                equations[indexE].Operator = '-'; i++;
            //                if (strGraph[i] == 'x')
            //                {
            //                    equations[indexE].Value = "1"; 
            //                }
            //                while (strGraph[i] != 'x' && strGraph[i] != '^' && strGraph[i] != ' ')
            //                        equations[indexE].Value += strGraph[i++];
            //                if (strGraph[i] == 'x')
            //                {
            //                    if (strGraph[i + 1] == '^')
            //                    {
            //                        equations[indexE].Class = strGraph[i + 2];
            //                        i += 3;
            //                    }
            //                    else
            //                    {
            //                        equations[indexE].Class = '1';
            //                        i++;
            //                    }
            //                }
            //                else
            //                {
            //                    equations[indexE].Class = '0';
            //                }
            //                indexE++;
            //            }
            //            break;
            //        }
            //    }


            //    Console.WriteLine("print a parametrim");
            //    for (int i = 0; i < count; i++)
            //    {
            //        equations[i].Value=equations[i].Value.Insert(0, Convert.ToString(equations[i].Operator));

            //        Console.WriteLine(equations[i].Value+", "+ equations[i].Operator+", " + equations[i].Class); 

            //    }

            //    double a = Convert.ToDouble(equations[0].Value);
            //    double b = Convert.ToDouble(equations[1].Value);
            //    double c = Convert.ToDouble(equations[2].Value);
            //    Console.WriteLine();
            //    Console.WriteLine("print a, b, c");
            //    Console.WriteLine("a= " + a + "\nb= " + b + "\nc= " + c);
            //    Console.WriteLine();



            //    //חישוב טרינום - נקודות חיתוך עם ציר האיקס
            //    double x1 = ((-b) + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            //    double x2 = ((-b) - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            //    Console.WriteLine("print Cutting points");
            //    Console.WriteLine("(" + x1 + ", 0)");
            //    Console.WriteLine("(" + x2 + ", 0)");
            //    Console.WriteLine();

            //    //חישוב נגזרת הפונקציה
            //    string derivative = (a * (Convert.ToInt32(equations[0].Class.ToString()))).ToString();//נגזרת
            //    derivative = derivative += "x "+ equations[1].Value;
            //    Console.WriteLine("f(x) = " + strGraph);
            //    Console.WriteLine("f'(x) = " + derivative);
            //    Console.WriteLine();

            //    //חישוב קודקוד הפונקציה - נקודת קיצון
            //    double Xkodkod = (-b) / (2 * a);
            //    double Ykodkod=(a*(Math.Pow(Xkodkod,Convert.ToInt32(equations[0].Class.ToString()))))
            //        +(b* (Math.Pow(Xkodkod, Convert.ToInt32(equations[1].Class.ToString()))))
            //        + (c * (Math.Pow(Xkodkod, Convert.ToInt32(equations[2].Class.ToString()))));
            //    Console.WriteLine("kodkod");
            //    Console.WriteLine("("+Xkodkod+", "+Ykodkod+ ")");


            //    Console.ReadLine();

            
            Equation e= Calculate.culc_parameters(str);
            Console.WriteLine();
            Console.WriteLine((Convert.ToInt32(e.Class)-48) + " class");
            foreach (var p in e.Parameters)
            {
                Console.WriteLine(p.Value + ", " + p.Operator + ", " + p.Class);
            }
            Console.ReadLine();

        }
    }
}
