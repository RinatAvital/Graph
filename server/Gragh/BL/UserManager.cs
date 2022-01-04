using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Web.UI.WebControls;

namespace BL
{
    class UserManager
    {
        static DBConection db = new DBConection();
        public static List<DtoUser> getUser()
        {
            List<Users> user = db.GetDbSet<Users>().ToList();
            List<DataList> list = DTOtoList(user);

            return null;
        }
        

    }
}
