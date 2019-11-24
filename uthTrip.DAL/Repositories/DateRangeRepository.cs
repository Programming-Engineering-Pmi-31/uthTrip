using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.DAL.Entities;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace uthTrip.DAL.Repositories

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
    public class DateRangeRepository : IRepository<Dates_ranges>
    {
        private uthtripContext db;
        public DateRangeRepository(uthtripContext context)
        {
            this.db = context;
        }
        public int MaxId()
        {
            int max = 0;
            try
            {
                 max = this.db.Dates_ranges.Max(a => a.Date_ID);
            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }
      

        public IEnumerable<Dates_ranges> GetAll()
        {
            return this.db.Dates_ranges;
        }

        public Dates_ranges Get(int id)
        {
            return this.db.Dates_ranges.Find(id);
        }

        public void Create(Dates_ranges dates_range)
        {
            this.db.Dates_ranges.Add(dates_range);
        }

        public void Update(Dates_ranges dates_range)
        {
            this.db.Entry(dates_range).State = EntityState.Modified;
        }

        public IEnumerable<Dates_ranges> Find(Func<Dates_ranges, bool> predicate)
        {
            return this.db.Dates_ranges.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dates_ranges dates_range = this.db.Dates_ranges.Find(id);
            if (dates_range != null)
                this.db.Dates_ranges.Remove(dates_range);
        }

        public Dates_ranges GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
