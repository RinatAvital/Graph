using BL.models;
using DTO;
using BL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GraphController : ApiController
    {
        

        // GET: api/Graph/getOneGraph
        public Equation GetOneGraph()
        {
            return BL.GraphManager.getOneGraph();
        }

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

        // POST: api/Graph/PostImportGraphString
        public Graphs PostImportGraphString(string graph, long userCode)
        {
           return BL.GraphManager.importGraph(graph, userCode);
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
