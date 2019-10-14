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
    public class BlockedUserRepository : IRepository<Blocked_Users>
    {
        private uthtripContext db;
        public int MaxId()
        {
            return 0;
        }
        public BlockedUserRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Blocked_Users> GetAll()
        {
            return db.Blocked_Users;
        }

        public Blocked_Users Get(int id)
        {
            return db.Blocked_Users.Find(id);
        }

        public void Create(Blocked_Users user)
        {
            db.Blocked_Users.Add(user);
        }

        public void Update(Blocked_Users user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<Blocked_Users> Find(Func<Blocked_Users, Boolean> predicate)
        {
            return db.Blocked_Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Blocked_Users user = db.Blocked_Users.Find(id);
            if (user != null)
                db.Blocked_Users.Remove(user);
        }
    }
}
