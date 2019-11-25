////using Microsoft.EntityFrameworkCore;

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

    public class TripRepository : IRepository<Trip>
    {
        private UthTripContext db;

        public TripRepository(UthTripContext context)
        {
            this.db = context;
        }

        public int MaxId()
        {
            int max;
            try
            {
                max = this.db.Trips.Max(a => a.Trip_ID);
            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }

        public IEnumerable<Trip> GetAll()
        {
            return this.db.Trips;
        }

        public Trip Get(int id)
        {
            return this.db.Trips.Find(id);
        }

        public void Create(Trip trip)
        {
            this.db.Trips.Add(trip);
        }

        public void Update(Trip trip)
        {
            this.db.Entry(trip).State = EntityState.Modified;
        }

        public IEnumerable<Trip> Find(Func<Trip, bool> predicate)
        {
            return this.db.Trips.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Trip trip = this.db.Trips.Find(id);
            if (trip != null)
            {
                this.db.Trips.Remove(trip);
            }
        }

        public Trip GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
