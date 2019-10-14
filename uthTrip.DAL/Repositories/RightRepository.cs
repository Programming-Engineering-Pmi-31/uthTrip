using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.DAL.Entities;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;
using System.Data.Entity;

namespace uthTrip.DAL.Repositories
{
    public class RightRepository : IRepository<Right>
    {
        private uthtripContext db;
        public int MaxId()
        {
            return 0;
        }
        public RightRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Right> GetAll()
        {
            return db.Rights;
        }

        public Right Get(int id)
        {
            return db.Rights.Find(id);
        }

        public void Create(Right right)
        {
            db.Rights.Add(right);
        }

        public void Update(Right right)
        {
            db.Entry(right).State = EntityState.Modified;
        }

        public IEnumerable<Right> Find(Func<Right, Boolean> predicate)
        {
            return db.Rights.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Right right = db.Rights.Find(id);
            if (right != null)
                db.Rights.Remove(right);
        }
    }
}
