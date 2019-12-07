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

    public class ReviewRepository : IRepository<Review>
    {
        private UthTripContext db;

        public ReviewRepository(UthTripContext context)
        {
            this.db = context;
        }

        public int MaxId()
        {
            int max;
            try
            {
                max = this.db.Reviews.Max(a => a.Review_ID);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }
            return max;
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
            ////this.db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return this.db.Reviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = this.db.Reviews.Find(id);
            if (review != null)
            {
                this.db.Reviews.Remove(review);
            }
        }

        public Review GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
