using DAL;
using Models;
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
            List<DtoUser> list = DtoUser.DTOtoList(user);
            return list;
        }
        

    }
}
