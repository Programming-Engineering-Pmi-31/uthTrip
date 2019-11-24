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
    public class RoleRepository : IRepository<Role>
    {
        private uthtripContext db;
        public int MaxId()
        {
            int max;
            try
            {
                max = db.Roles.Max(a => a.Role_ID);
            }
            catch (System.InvalidOperationException)
            { max = -1; }
            return max;
        }
        public RoleRepository(uthtripContext context)
        {
            this.db = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles;
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }

        public void Create(Role role)
        {
            db.Roles.Add(role);
        }

        public void Update(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
        }

        public IEnumerable<Role> Find(Func<Role, Boolean> predicate)
        {
            return db.Roles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Role role = db.Roles.Find(id);
            if (role != null)
                db.Roles.Remove(role);
        }

        public Role GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
