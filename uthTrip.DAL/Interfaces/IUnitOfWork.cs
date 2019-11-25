namespace UthTrip.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.DAL.Entities;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Role> Roles { get; }
        IRepository<Right> Rights { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Destination> Destinations { get; }
        IRepository<Dates_ranges> Dates_ranges { get; }
        IRepository<Blocked_Users> Blocked_Users { get; }
        void Save();
    }
}
