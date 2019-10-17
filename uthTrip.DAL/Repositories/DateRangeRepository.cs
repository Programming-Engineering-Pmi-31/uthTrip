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
    public class DateRangeRepository : IRepository<Dates_ranges>
    {
        private uthtripContext db;
        public int MaxId()
        {
            return 0;
        }
        public DateRangeRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dates_ranges> GetAll()
        {
            return db.Dates_ranges;
        }

        public Dates_ranges Get(int id)
        {
            return db.Dates_ranges.Find(id);
        }

        public void Create(Dates_ranges dates_range)
        {
            db.Dates_ranges.Add(dates_range);
        }

        public void Update(Dates_ranges dates_range)
        {
            db.Entry(dates_range).State = EntityState.Modified;
        }

        public IEnumerable<Dates_ranges> Find(Func<Dates_ranges, Boolean> predicate)
        {
            return db.Dates_ranges.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dates_ranges dates_range = db.Dates_ranges.Find(id);
            if (dates_range != null)
                db.Dates_ranges.Remove(dates_range);
        }

        public Dates_ranges GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
