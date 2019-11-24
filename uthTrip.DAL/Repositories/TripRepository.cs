using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.DAL.Entities;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;

//using Microsoft.EntityFrameworkCore;

namespace uthTrip.DAL.Repositories
{
    public class TripRepository : IRepository<Trip>
    {
        private uthtripContext db;
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
        public TripRepository(uthtripContext context)
        {
            this.db = context;
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

        public IEnumerable<Trip> Find(Func<Trip, Boolean> predicate)
        {
            return this.db.Trips.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Trip trip = this.db.Trips.Find(id);
            if (trip != null)
                this.db.Trips.Remove(trip);
        }

        public Trip GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
