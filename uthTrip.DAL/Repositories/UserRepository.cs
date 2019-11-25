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

    public class UserRepository : IRepository<User>
    {
        private UthTripContext db;

        public UserRepository(UthTripContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return this.db.Users;
        }

        public User Get(int id)
        {
            return this.db.Users.Find(id);
        }

        public void Create(User user)
        {
            this.db.Users.Add(user);
        }

        public void Update(User user)
        {
            this.db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return this.db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = this.db.Users.Find(id);
            if (user != null)
            {
                this.db.Users.Remove(user);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Users.Max(a => a.User_ID);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }

        public User GetbyPass(string username, string password)
        {
            return this.db.Users.Where(a => a.Username == username && a.Password == password).ToList().FirstOrDefault();
        }
    }
}
