using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class userDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public userDetails(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        //public userDetails(userDetails ud)
        //{
        //    this.UserName = ud.UserName;
        //    this.Password = ud.Password;
        //}
    }
}
