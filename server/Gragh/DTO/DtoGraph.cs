using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace DTO
{
    public class DtoGraph
    {
        public long graphCode { get; set; }
        public string graphString { get; set; }
        public long userCode { get; set; }
        public DateTime creationDate { get; set; }

        public DtoGraph(Graphs g)
        {
            graphCode = (long)g.graphCode;
            graphString = g.graphString;
            userCode = (long)g.userCode;
            creationDate = (DateTime)g.creationDate;
        }
        public static List<DtoGraph> DTOtoList(List<Graphs> list)
        {
            List<DtoGraph> DTOlist = new List<DtoGraph>();
            foreach (var u in list)
            {
                DTOlist.Add(new DtoGraph(u));
            }
            return DTOlist;
        }
    }
}
