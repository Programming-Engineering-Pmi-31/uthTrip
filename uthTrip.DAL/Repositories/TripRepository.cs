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
    public class TripRepository : IRepository<Trip>
    {
        private uthtripContext db;
        public int MaxId()
        {
            int max = db.Trips.Max(a => a.Trip_ID);
            return max;
        }
        public TripRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Trip> GetAll()
        {
            return db.Trips;
        }

        public Trip Get(int id)
        {
            return db.Trips.Find(id);
        }

        public void Create(Trip trip)
        {
            db.Trips.Add(trip);
        }

        public void Update(Trip trip)
        {
            db.Entry(trip).State = EntityState.Modified;
        }

        public IEnumerable<Trip> Find(Func<Trip, Boolean> predicate)
        {
            return db.Trips.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Trip trip = db.Trips.Find(id);
            if (trip != null)
                db.Trips.Remove(trip);
        }
    }
}
