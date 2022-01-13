using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DAL;

namespace API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default/GetAllUser
        public List<DtoUser> GetAllUser()
        {
            return BL.UserManager.getUser();
        }

        // POST: api/Default
        public Users PostSignUp([FromBody]DtoUser user)
        {
            return BL.UserManager.signUp(user);
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
