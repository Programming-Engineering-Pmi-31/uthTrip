namespace UthTrip.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    using UthTrip.DAL.Interfaces;

    public class EFUnitOfWork : IUnitOfWork
    {
        private UthTripContext db;
        private UserRepository userRepository;
        private TripRepository tripRepository;
        private ReviewRepository reviewRepository;
        private BlockedUserRepository blockedUserRepository;
        private DateRangeRepository dateRangeRepository;
        private DestinationRepository destinationRepository;
        private RoleRepository roleRepository;
        private RightRepository rightRepository;
        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            this.db = new UthTripContext(connectionString);
        }

        public EFUnitOfWork(UthTripContext db)
        {
            this.db = db;
            this.userRepository = new UserRepository(db);
            this.tripRepository = new TripRepository(db);
            this.reviewRepository = new ReviewRepository(db);
            this.blockedUserRepository = new BlockedUserRepository(db);
            this.dateRangeRepository = new DateRangeRepository(db);
            this.destinationRepository = new DestinationRepository(db);
            this.roleRepository = new RoleRepository(db);
            this.rightRepository = new RightRepository(db);
        }

        public IRepository<User> Users
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.db);
                }

                return this.userRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (this.tripRepository == null)
                {
                    this.tripRepository = new TripRepository(this.db);
                }

                return this.tripRepository;
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new ReviewRepository(this.db);
                }

                return this.reviewRepository;
            }
        }

        public IRepository<Blocked_Users> Blocked_Users
        {
            get
            {
                if (this.blockedUserRepository == null)
                {
                    this.blockedUserRepository = new BlockedUserRepository(this.db);
                }

                return this.blockedUserRepository;
            }
        }

        public IRepository<Dates_ranges> Dates_ranges
        {
            get
            {
                if (this.dateRangeRepository == null)
                {
                    this.dateRangeRepository = new DateRangeRepository(this.db);
                }

                return this.dateRangeRepository;
            }
        }

        public IRepository<Destination> Destinations
        {
            get
            {
                if (this.destinationRepository == null)
                {
                    this.destinationRepository = new DestinationRepository(this.db);
                }

                return this.destinationRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(this.db);
                }

                return this.roleRepository;
            }
        }

        public IRepository<Right> Rights
        {
            get
            {
                if (this.rightRepository == null)
                {
                    this.rightRepository = new RightRepository(this.db);
                }

                return this.rightRepository;
            }
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}