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
        public static List<DtoGraph> getGraph()
        {
            List<Graphs> graph = db.GetDbSet<Graphs>().ToList();
            return DtoGraph.DTOtoList(graph);

        }

    }
}
