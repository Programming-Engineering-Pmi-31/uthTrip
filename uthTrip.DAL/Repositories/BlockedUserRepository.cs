namespace uthTrip.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using uthTrip.DAL.EF;
    using uthTrip.DAL.Entities;
    using uthTrip.DAL.Interfaces;
    public class BlockedUserRepository : IRepository<Blocked_Users>
    {
        private uthtripContext db;
        public BlockedUserRepository(uthtripContext context)
        {
            this.db = context;
        }
        public int MaxId()
        {
            return 0;
        }
        

        public IEnumerable<Blocked_Users> GetAll()
        {
            return this.db.Blocked_Users;
        }

        public Blocked_Users Get(int id)
        {
            return this.db.Blocked_Users.Find(id);
        }

        public void Create(Blocked_Users user)
        {
            this.db.Blocked_Users.Add(user);
        }

        public void Update(Blocked_Users user)
        {
            ////this.db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<Blocked_Users> Find(Func<Blocked_Users, bool> predicate)
        {
            return this.db.Blocked_Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Blocked_Users user = this.db.Blocked_Users.Find(id);
            if (user != null)
                this.db.Blocked_Users.Remove(user);
        }

        public Blocked_Users GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
