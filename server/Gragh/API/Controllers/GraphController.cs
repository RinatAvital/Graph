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
        //public Equation GetOneGraph()
        //{
        //    return BL.GraphManager.getOneGraph();
        //}

        // GET: api/Graph/GetAllGraph
        public List<DtoGraph> GetAllGraph()
        {
            return BL.GraphManager.getGraphs();
        }



        // POST: api/Graph/PostPointGraph
        public List<Point> PostPointGraph(Equation e)
        {
            return BL.GraphManager.getPointGraph(e);
        }

        // POST: api/Graph/PostImportGraphString
        //מחזיר אובייקט משוואה שהתקבל מהמשתמש
        public Equation PostImportGraphString(graphNew graph)
        {
            return BL.GraphManager.importGraph(graph.graphString,graph.userCode);
        }

        // POST: api/Graph/PostNigzeret
        public Equation PostNigzeret(Equation equation)
        {
            return BL.GraphManager.getNigzeret(equation);
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
