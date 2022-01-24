using BL.models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class GraphController : ApiController
    {
        // GET: api/Graph/getOneGraph
        //public List<Point> GetOneGraph()
        //{
        //    return BL.GraphManager.getOneGraph();
        //}

        // GET: api/Graph/GetAllGraph
        public List<DtoGraph> GetAllGraph()
        {
            return BL.GraphManager.getGraphs();
        }

        // GET: api/Graph/GetNigzeret
        public Equation GetNigzeret()
        {
            return BL.GraphManager.getNigzeret();
        }

        // POST: api/Graph
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Graph/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Graph/5
        public void Delete(int id)
        {
        }
    }
}
