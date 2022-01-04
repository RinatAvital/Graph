using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    class DtoUser
    {
        public long Code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public DtoUser(Users u)
        {
            Code = u.Code;
            firstName = u.firstName;
            lastName = u.lastName;
            userName = u.userName;
            email = u.email;
            password = u.password;

        } 
        public static List<DtoUser> DTOtoList(List<Users> list)
        {
            List<DtoUser> DTOlist = new List<DtoUser>();
            foreach (var u in list)
            {
                DTOlist.Add(new DtoUser(u));
            }
            return DTOlist;
        }
    }
}
