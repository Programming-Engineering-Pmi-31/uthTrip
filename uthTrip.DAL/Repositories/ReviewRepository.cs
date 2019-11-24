using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.DAL.Entities;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public class ReviewRepository : IRepository<Review>
    {
        private uthtripContext db;
        public ReviewRepository(uthtripContext context)
        {
            this.db = context;
        }
        public int MaxId()
        {
            return 0;
        }
       

        public IEnumerable<Review> GetAll()
        {
            return this.db.Reviews;
        }

        public Review Get(int id)
        {
            return this.db.Reviews.Find(id);
        }

        public void Create(Review review)
        {
            this.db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            this.db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return this.db.Reviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = this.db.Reviews.Find(id);
            if (review != null)
                this.db.Reviews.Remove(review);
        }

        public Review GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
