using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class Calculate
    {
        //פונקציה המקבלת מחרוזת של פונקציה ומכניסה אותה לתוך אובייקט משוואה 
        public static Equation getEquationFromStr(string str)
        {
            string strCopy = str;
            //מסיר רווחים לא תקינים שנוצרים ויוצר רווח לפני כל איבר חדש
            string strGraph = string.Join(" ", strCopy
               .Replace(" ", "") // remove all spaces because they kind of random now
               .Replace("+", " +") // add space to signs to keep them with their value
               .Replace("-", " -")
               .Split(' '));
            //כאשר המחרוזת מתחילה באיבר שהוא שלילי (-) יש להסיר את הרווח המיותר
            //ע"י העברת המחרוזת לרשימה והחזרתה שוב למחרוזת רגילה
            if (strGraph[0] == ' ')
            {
                //strGraph = strGraph.Skip(0).ToString();
                List<char> strGraphList = new List<char>(strGraph);
                strGraphList.RemoveAt(0);
                //strGraph = strGraphList.ToArray().ToString();
                strGraph = "";
                foreach (var i in strGraphList)
                {
                    strGraph += i;
                }
            }

            //split- נפרק את המחרוזת מערך של איברים ע"י 
            //עבור כל רווח במחרוזת מפרק לאיבר חדש
            string[] s = strGraph.Split(' ');
            //בדיקת כמות האיברים בפונקציה
            int count = strGraph.Count(f => f == ' ') + 1;

            //יצירת פונקציה חדשה ורשימת פרמטרים אליה יוכנסו נתוני המשוואה
            Equation equation = new Equation();
            equation.Parameters = new List<Parameter>();
            //עובר על כל איבר במשוואה
            for (int i = 0; i < s.Length && s.Length != 0; i++)
            {
                //יצירת איבר - פרמטר לאיבר יחיד שיוכנס לרשימת הפרמטרים- האיברים
                Parameter p = new Parameter();
                //בדיקת מעלת הפרמטר
                switch (s[i][s[i].Length - 1])//התו האחרון באיבר הראשון
                {
                    //אם התו איקס הוא האחרון באיבר סימן שהמעלה שלו היא 1
                    case 'x':
                        {
                            p.Class = 1;//מכניס את מעלת האיבר
                            break;
                        }
                    default:
                        {
                            //אם המקום השני מהסוף הוא גג (חזקה) נכניס את המעלה שנמצאת במקום האחרון באיבר
                            if (s[i][s[i].Length - 2] == '^')//להגביל מעלה גבוהה
                            {
                                p.Class = Convert.ToInt32(s[i][s[i].Length - 1]) - 48;//מכניס את מעלת האיבר
                            }
                            //אחרת המעלה היא 0
                            else
                                p.Class = 0;

                            break;
                        }
                }
                //שולח את האיבר ואת אובייקט הפרמטר ומסיים לאכסן את האיבר...
                calcOperator(p, s[i]);
                //מוסיף את האיבר הבודד לרימת האיברים - פרמטרים
                equation.Parameters.Add(p);
            }
            //ממיין ע"פ מעלת האיברים מהגדול לקטן
            equation.Parameters = equation.Parameters.OrderByDescending(c => c.Class).ToList();
            //מעדכן את מעלת הפונקציה הגבוה ביותר וכן את מספר האיברים בפונקציה
            equation.Class = equation.Parameters.Max(m => m.Class);
            equation.Count = count;
            return equation;
        }

        // פונקציה המקבלת את האיבר ואת אובייקט הפרמטר ומסיים לאכסן את האיבר 
        public static void calcOperator(Parameter p, string v)
        {
            int i = 0;
            //מכניס בהתאמה את אופרטור האיבר
            p.Operator = '+';
            if (v[i] == '-')
            {
                p.Operator = '-';
                //אם האופרטור הוא '-' אז צריך לקדם לתו הבא
                i++;
            }
            //אם לא קיים ערך 
            if (v[i] == 'x') p.Value = 1;
            //כאשר קיים ערך 
            else
            {
                //מסירים מהאיבר את כל התוים השונים מהערך וממינים ע"פ אורך הגדול
                string s = v.Split('+', '-', '^', 'x').OrderByDescending(x => x.Length).ToArray()[0];
                p.Value = Convert.ToDouble(s);

            }
        }
        public static List<Point> getPoint(Equation equation)
        {
            return print(equation);
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
