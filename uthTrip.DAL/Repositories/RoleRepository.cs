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

    public class RoleRepository : IRepository<Role>
    {
        private UthTripContext db;

        public RoleRepository(UthTripContext context)
        {
            this.db = context;
        }

        public int MaxId()
        {
            int max;
            try
            {
                max = this.db.Roles.Max(a => a.Role_ID);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }
            return max;
        }

        public IEnumerable<Role> GetAll()
        {
            return this.db.Roles;
        }

        public Role Get(int id)
        {
            return this.db.Roles.Find(id);
        }

        public void Create(Role role)
        {
            this.db.Roles.Add(role);
        }

        public void Update(Role role)
        {
            ////this.db.Entry(role).State = EntityState.Modified;
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return this.db.Roles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Role role = this.db.Roles.Find(id);
            if (role != null)
            {
                this.db.Roles.Remove(role);
            }
        }

        public Role GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
