namespace uthTrip.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using uthTrip.DAL.EF;
    using uthTrip.DAL.Entities;
    using uthTrip.DAL.Interfaces;

    public class DestinationRepository : IRepository<Destination>
    {
        private uthtripContext db;
        public DestinationRepository(uthtripContext context)
        {
            this.db = context;
        }
        public int MaxId()
        {
            int max;
            try
            {
                 max = this.db.Destinations.Max(a => a.Destination_ID);

            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }

        public IEnumerable<Destination> GetAll()
        {
            return this.db.Destinations;
        }

        public Destination Get(int id)
        {
            return this.db.Destinations.Find(id);
        }

        public void Create(Destination destination)
        {
            this.db.Destinations.Add(destination);
        }

        public void Update(Destination destination)
        {
            ////this.db.Entry(destination).State = EntityState.Modified;
        }

        public IEnumerable<Destination> Find(Func<Destination, bool> predicate)
        {
            return this.db.Destinations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Destination destination = this.db.Destinations.Find(id);
            if (destination != null)
                this.db.Destinations.Remove(destination);
        }

        public Destination GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
