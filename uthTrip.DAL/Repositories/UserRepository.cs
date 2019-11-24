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
    public class UserRepository : IRepository<User>
    {
        private uthtripContext db;

        public UserRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
        public int MaxId()
        {
            int max = 0;
            try
            {
                 max = db.Users.Max(a => a.User_ID);
            }
            catch(System.InvalidOperationException)
            {  max= -1; }
            return max;

        }

        public User GetbyPass(string username, string password)
        {
            return db.Users.Where(a => a.Username == username && a.Password==password).ToList().FirstOrDefault();
        }
    }
}
