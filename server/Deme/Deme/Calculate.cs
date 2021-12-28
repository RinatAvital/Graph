using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deme
{
    public static class Calculate
    {
        

        //פונקציה מקבלת מחרוזת ומחזירה רשימת פרמטרים
        public static Equation culc_parameters(string str)
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

            

            Console.WriteLine(count);

            //int s= strGraph.IndexOf(" ");

            char maxC='0';
            for (int i = 0; i < strGraph.Length - 3; i++)
            {
                switch (strGraph[i])
                {
                    case '+':
                        {
                            Parameter p = new Parameter();
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
            e.Class = maxC;
            e.Parameters = Equations;

            return e;
        }

       
    }
}
