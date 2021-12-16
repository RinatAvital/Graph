using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace DAL
{
    public class DBConection
    {
        public DBConection() { }
        public List<T> GetDbSet<T>() where T : class
        {
            using (GraphEntities db = new GraphEntities())
            {
                return db.GetDbSet<T>().ToList();
            }
        }
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (GraphEntities db = new GraphEntities())
            {
                var DB = db.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        DB.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        DB.Attach(entity);
                        db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteActions.Delete:
                        DB.Attach(entity);
                        db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();

            }
        }
    }
}
