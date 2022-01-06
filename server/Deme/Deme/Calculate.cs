using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deme
{
    public static class Calculate
    {
        /// <summary>
        /// פונקציה מקבלת מחרוזת ומחזירה אובייקט עם רשימת פרמטרים והמעלה המקסימלית
        /// </summary>
        /// <param name="str"> מחרוזת המשוואה</param>
        
      /*  public static void culc_parameters(string str)
        {
            List<Parameter> Equations = new List<Parameter>();
            Equation e = new Equation();

            string strCopy = str;

            if (str.Length != 0 && str[0] != '-') // covers case when first member is positive, if it is not enough you can use str.TrimStart()[0]
            {
                strCopy = "+" + str;
            }
            string strGraph = string.Join(" ", strCopy
                .Replace(" ", "") // remove all spaces because they kind of random now
                .Replace("+", " +") // add space to signs to keep them with their value
                .Replace("-", " -")
                .Split(' '));
            strGraph = strGraph.Remove(0, 1);//מוחק את הרווח הראשון 
            strGraph = strGraph.Insert(strGraph.Length, "  ");

            //בדיקת כמות האיברים בפונקציה
            int count = strGraph.Count(f => f == ' ') - 1;

            

            //Console.WriteLine(count);

            //int s= strGraph.IndexOf(" ");

            char maxC='0';
            for (int i = 0; i < strGraph.Length - 3; i++)
            {
                switch (strGraph[i])
                {
                    case '+':
                        {
                            Parameter p = new Parameter();
                            p.Value += '+';
                            p.Operator = '+'; i++;
                            if (strGraph[i] == 'x')
                            {
                                p.Value = "1";
                            }
                            while (strGraph[i] != 'x' && strGraph[i] != '^' && strGraph[i] != ' ')
                                p.Value += strGraph[i++];

                            if (strGraph[i] == 'x')
                            {
                                if (strGraph[i + 1] == '^')
                                {
                                    p.Class = strGraph[i + 2];
                                    if (p.Class > maxC) maxC = p.Class;
                                    i += 3;
                                }
                                else
                                {
                                    p.Class = '1';
                                    if (p.Class > maxC) maxC = p.Class;
                                    i++;
                                }
                            }
                            else
                            {
                                p.Class = '0';
                            }
                            Equations.Add(p);
                        }
                        break;
                    case '-':
                        {
                            Parameter p = new Parameter();
                            p.Value += '-';
                            p.Operator = '-'; i++;
                            if (strGraph[i] == 'x')
                            {
                                p.Value = "1";
                            }
                            while (strGraph[i] != 'x' && strGraph[i] != '^' && strGraph[i] != ' ')
                                p.Value += strGraph[i++];
                            if (strGraph[i] == 'x')
                            {
                                if (strGraph[i + 1] == '^')
                                {
                                    p.Class = strGraph[i + 2];
                                    if (p.Class > maxC) maxC = p.Class;
                                    i += 3;
                                }
                                else
                                {
                                    p.Class = '1';
                                    if (p.Class > maxC) maxC = p.Class;
                                    i++;
                                }
                            }
                            else
                            {
                                p.Class = '0';
                            }
                            Equations.Add(p);
                        }
                        break;
                }
            }

            List<Parameter> eq = Equations.OrderByDescending(c => c.Class).ToList();
            
            e.Class = maxC;
            e.Count = count;
            e.Parameters = eq;

            Console.WriteLine((Convert.ToInt32(e.Class) - 48) + " class");
            Console.WriteLine("mis evarim "+count);
            foreach (var p in e.Parameters)
            {
                Console.WriteLine(p.Value + ", " + p.Operator + ", " + p.Class);
            }

            Console.WriteLine();
            List<Point> points= Point.culc_points(e);
            foreach (var p in points)
            {
                p.ToPrintPoint();
            }

        }
        */
        public static void Advancedculc_parameters(string str)
        {
            List<Parameter> Equations = new List<Parameter>();
            Equation e = new Equation();

            string strCopy = str;
            string strGraph = string.Join(" ", strCopy
               .Replace(" ", "") // remove all spaces because they kind of random now
               .Replace("+", " +") // add space to signs to keep them with their value
               .Replace("-", " -")
               .Split(' '));

           string [] s= strGraph.Split(' ');


            Equation equation = new Equation();
            equation.Parameters = new List<Parameter>();

            for (int i = 0; i < s.Length&&s.Length!=0; i++)
            {
                Parameter p = new Parameter();
                //בדיקת מעלת הפרמטר
                switch (s[i][s[i].Length-1])
                {
                    case 'x':
                        {
                            p.Class = 1;
                            break;
                        }              
                    default:
                        {
                            if (s[i][s[i].Length-2] == '^')//להגביל מעלה גבוהה
                            {
                                p.Class = Convert.ToInt32(s[i][s[i].Length - 1]);
                            }
                            else
                                p.Class = 0;

                        break;}
                }
                calcOperator(p,s[i]);
            }

        }

        public static void calcOperator(Parameter p, string v)
        {
            p.Operator = '+';
            if (v[0] == '-')
                p.Operator = '-';
            string s = v.Split('+', '-', '^', 'x').OrderByDescending(x=>x.Length).ToArray()[0] ;
            p.Value = Convert.ToDouble(s);
      
           
        }
    }
}
