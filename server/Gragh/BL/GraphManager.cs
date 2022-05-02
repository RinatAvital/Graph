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

        public static List<Point> getPointGraph()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            List<DtoGraph> g = DtoGraph.DTOtoList(graph);
            Equation equation = Calculate.getEquationFromStr(g[1].graphString);
            return Point.culc_points(equation);
            //return Calculate.getPoint(equation);
            //return new DtoGraph(g, points);
        }

        //public static Equation getOneGraph()
        //{
        //    List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
        //    List<DtoGraph> g = DtoGraph.DTOtoList(graph);
        //    //return Calculate.getEquationFromStr(g[4].graphString);
        //    int length = g.Count-1;
        //    return Calculate.getEquationFromStr(g[length].graphString);
        //    //return Calculate.getPoint(equation).;
        //    //return new DtoGraph(g, points);
        //}

        public static Equation getNigzeret(Equation equation)
        {
            //List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            //List<DtoGraph> g = DtoGraph.DTOtoList(graph);
            //int length = g.Count - 1;
            //Equation f = Calculate.getEquationFromStr(g[length].graphString);
            return Point.calc_nigzeret(equation);
        }
        //מקבל מחרוזת גרף וקוד משתמש ויוצר אובייקט גרף חדש בשרת
        public static Equation importGraph(string graph, long userCode)
        {
            DtoGraph g = new DtoGraph(graph, userCode, DateTime.Now);
            Graphs graphs = g.toTableEntity();
            db.Execute<Graphs>(graphs, DBConection.ExecuteActions.Insert);
            return Calculate.getEquationFromStr(g.graphString);
            //return graphs;
        }


    }
}
