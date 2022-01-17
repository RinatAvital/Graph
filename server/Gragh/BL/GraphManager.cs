using BL.models;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GraphManager
    {
        static DBConection db = new DBConection();
        public static List<DtoGraph> getGraphs()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            return DtoGraph.DTOtoList(graph);

        }

        public static void getOneGraph()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            List<DtoGraph> g = DtoGraph.DTOtoList(graph);
            //return g[0].graphString;
            Calculate.Advancedculc_parameters(g[0].graphString);
        }

    }
}
