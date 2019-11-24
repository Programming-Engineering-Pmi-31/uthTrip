namespace UthTrip.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    using UthTrip.DAL.Interfaces;
    public class RightRepository : IRepository<Right>
    {
        private uthtripContext db;
        public RightRepository(uthtripContext context)
        {
            this.db = context;
        }
        public int MaxId()
        {
            int max;
            try
            {
                max = this.db.Rights.Max(a => a.Rights_ID);
            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }

        public IEnumerable<Right> GetAll()
        {
            return this.db.Rights;
        }

        public Right Get(int id)
        {
            return this.db.Rights.Find(id);
        }

        public void Create(Right right)
        {
            this.db.Rights.Add(right);
        }

        public void Update(Right right)
        {
            this.db.Entry(right).State = EntityState.Modified;
        }

        public IEnumerable<Right> Find(Func<Right, bool> predicate)
        {
            return this.db.Rights.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Right right = this.db.Rights.Find(id);
            if (right != null)
                this.db.Rights.Remove(right);
        }

        public Right GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
