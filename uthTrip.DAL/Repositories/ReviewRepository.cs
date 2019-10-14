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
    public class ReviewRepository : IRepository<Review>
    {
        private uthtripContext db;
        public int MaxId()
        {
            return 0;
        }
        public ReviewRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviews;
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public void Create(Review review)
        {
            db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, Boolean> predicate)
        {
            return db.Reviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
                db.Reviews.Remove(review);
        }
    }
}
