using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DTO
{
    public class DtoGraph
    {
        public int graphCode { get; set; }
        public string graphString { get; set; }
        public int userCode { get; set; }
        public DateTime creationDate { get; set; }

        public DtoGraph(string graph, int usercode, DateTime dateTime)
        {
            this.graphCode = 0;
            this.graphString = graph;
            this.userCode = usercode;
            this.creationDate = DateTime.Now;
            
        }
        public DtoGraph(Graphs g)
        {
            graphCode = (int)g.graphCode;
            graphString = g.graphString;
            userCode = (int)g.userCode;
            creationDate = (DateTime)g.creationDate;
        }
        public static List<DtoGraph> DTOtoList(List<Graphs> list)
        {
            List<DtoGraph> DTOlist = new List<DtoGraph>();
            foreach (var g in list)
            {
                DTOlist.Add(new DtoGraph(g));
            }
            return DTOlist;
        }

        public Graphs toTableEntity()
        {
            Graphs g = new Graphs();
            g.graphCode = graphCode;
            g.graphString = graphString;
            g.userCode = userCode;
            g.creationDate = creationDate;
            return g;
        }
    }
}
