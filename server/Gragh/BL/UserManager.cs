using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class UserManager
    {
        static DBConection db = new DBConection();
        public static List<DtoUser> getUser()
        {
            List<Users> user = db.GetDbSet<Users>().ToList();
            return DtoUser.DTOtoList(user);
            
        }
        public static Users signUp(DtoUser user)
        {
            Users u = user.toTableEntity();
            db.Execute<Users>(u, DBConection.ExecuteActions.Insert);
            return u;
        }




    }
}
