using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class graphNew
    {
        public string graphString { get; set; }
        public int userCode { get; set; }

        public graphNew(string graphString, int userCode)
        {
            this.graphString = graphString;
            this.userCode = userCode;
        }
        //public graphNew(userDetails ud)
        //{
        //    this.UserName = ud.UserName;
        //    this.Password = ud.Password;
        //}

    }
}
