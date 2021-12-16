using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deme
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            Prameter[] equations = new Prameter[3];
            for (int i = 0; i < equations.Length; i++)       
            {
                equations[i] = new Prameter();
            }


            string expression = "x^2-2x+2";
            for (int i = 0; i < expression.Length; i++)
            {
                int mone = 0;
                int ii = 0;
                switch (expression[i])
                {
                    case 'x':{
                        equations[mone].Value = 1;
                        equations[mone].Operator = '+';
                        if (expression[i + 1] == '^')
                            equations[mone].Class = expression[ii + 2] + 1;
                        mone++;
                        ii += 2;
                    }
                    break;
                    case '+': {
                        equations[mone].Value =  Convert.ToInt32(equations[ii+1]);
                        equations[mone].Operator = '+';
                        equations[mone].Class = expression[i + 2] + 1;
                        }
                    break;
                }
                
            }
        }
    }
}
