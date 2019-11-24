using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.DAL.Entities;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace uthTrip.DAL.Repositories
{
    public class DestinationRepository : IRepository<Destination>
    {
        private uthtripContext db;
        public int MaxId()
        {
            int max;
            try
            {
                 max = db.Destinations.Max(a => a.Destination_ID);

            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }
        public DestinationRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Destination> GetAll()
        {
            return db.Destinations;
        }

        public Destination Get(int id)
        {
            return db.Destinations.Find(id);
        }

        public void Create(Destination destination)
        {
            db.Destinations.Add(destination);
        }

        public void Update(Destination destination)
        {
            db.Entry(destination).State = EntityState.Modified;
        }

        public IEnumerable<Destination> Find(Func<Destination, Boolean> predicate)
        {
            return db.Destinations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Destination destination = db.Destinations.Find(id);
            if (destination != null)
                db.Destinations.Remove(destination);
        }

        public Destination GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
