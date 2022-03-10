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
            Equation equation = Calculate.getEquationFromStr(g[1].graphString);
            return Calculate.getPoint(equation);
            //return new DtoGraph(g, points);
        }
        public static Equation getNigzeret()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            List<DtoGraph> g = DtoGraph.DTOtoList(graph);
            Equation f = Calculate.getEquationFromStr(g[1].graphString);
            return Point.calc_nigzeret(f);
        }


    }
}
