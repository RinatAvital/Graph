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

namespace API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default/GetAllUser
        public List<DtoUser> GetAllUser()
        {
            return BL.UserManager.getUser();
        }

        // POST: api/Default/PostSignUp
        public Users PostSignUp([FromBody]DtoUser user)
        {
            return BL.UserManager.signUp(user);
        }
        // POST: api/Default/PostLogIn
        public DtoUser PostLogIn([FromBody]userDetails user)
        {
            return BL.UserManager.loginUser(user.UserName, user.Password);
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
