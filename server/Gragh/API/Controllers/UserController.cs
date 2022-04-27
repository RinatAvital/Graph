using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DAL;
using BL.models;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/User/GetAllUser
        public List<DtoUser> GetAllUser()
        {
            return BL.UserManager.getUser();
        }

        // POST: api/User/PostSignUp
        public Users PostSignUp(DtoUser user)
        {
            return BL.UserManager.signUp(user);
        }
        // POST: api/User/PostSignIn
        public Users PostSignIn(userDetails user)
        {
            return BL.UserManager.signIn(user.UserName, user.Password);
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
