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

        public static List<Point> getOneGraph()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            List<DtoGraph> g = DtoGraph.DTOtoList(graph);
            List<Point> points = Calculate.Advancedculc_parameters(g[1].graphString);
            return points;
            //return new DtoGraph(g, points);

        }

    }
}
