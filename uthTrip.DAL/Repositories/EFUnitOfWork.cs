using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip;
using uthTrip.DAL.EF;
using uthTrip.DAL.Interfaces;
using uthTrip.DAL.Entities;
 
namespace uthTrip.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private uthtripContext db;
        private UserRepository userRepository;
        private TripRepository tripRepository;
        private ReviewRepository reviewRepository;
        private BlockedUserRepository blockedUserRepository;
        private DateRangeRepository dateRangeRepository;
        private DestinationRepository destinationRepository;
        private RoleRepository roleRepository;
        private RightRepository rightRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new uthtripContext(connectionString);
        }
        
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (tripRepository == null)
                    tripRepository = new TripRepository(db);
                return tripRepository;
            }
        }
        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }
        public IRepository<Blocked_Users> Blocked_Users
        {
            get
            {
                if (blockedUserRepository == null)
                    blockedUserRepository = new BlockedUserRepository(db);
                return blockedUserRepository;
            }
        }
        public IRepository<Dates_ranges> Dates_ranges
        {
            get
            {
                if (dateRangeRepository == null)
                    dateRangeRepository = new DateRangeRepository(db);
                return dateRangeRepository;
            }
        }
        public IRepository<Destination> Destinations
        {
            get
            {
                if (destinationRepository == null)
                    destinationRepository = new DestinationRepository(db);
                return destinationRepository;
            }
        }
        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }
        public IRepository<Right> Rights
        {
            get
            {
                if (rightRepository == null)
                    rightRepository = new RightRepository(db);
                return rightRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public EFUnitOfWork(uthtripContext db)
        {
            this.db = db;
            userRepository = new UserRepository(db);
            tripRepository = new TripRepository(db);
            reviewRepository = new ReviewRepository(db);
            blockedUserRepository = new BlockedUserRepository(db);
            dateRangeRepository = new DateRangeRepository(db);
            destinationRepository = new DestinationRepository(db);
            roleRepository = new RoleRepository(db);
            rightRepository = new RightRepository(db);

        }
    }
}