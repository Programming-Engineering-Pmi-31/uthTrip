namespace UthTrip.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    ////using UthTrip.BLL.BusinessModels;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.DAL.Entities;
    using UthTrip.DAL.Interfaces;

    public class TripService : ITripService
    {
        public TripService()
        {
        }

        public TripService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        private IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Trips.MaxId();
            return max;
        }

        public void CreateTrip(TripDTO tripDto, DestinationDTO destinationDTO, DatesRangeDTO datesRangeDTO)
        {
            Trip trip = new Trip
            {
                Trip_ID = tripDto.Trip_ID,
                Trip_Title = tripDto.Trip_Title,
                Description = tripDto.Description,
                Price = tripDto.Price,
                Date_ID = tripDto.Date_ID,
                Number_Of_People = tripDto.Number_Of_People,
                Destination_ID = tripDto.Destination_ID,
                Creator_ID = tripDto.Creator_ID,
            };
            Destination destination = new Destination
            {
                Destination_ID = destinationDTO.Destination_ID,
                Is_Abroad = destinationDTO.Is_Abroad,
                Country = destinationDTO.Country,
                City = destinationDTO.City,
            };
            Dates_ranges dates_Ranges = new Dates_ranges
            {
                Date_ID = datesRangeDTO.Date_ID,
                Start_date = datesRangeDTO.Start_date,
                End_date = datesRangeDTO.End_date,
            };
            try
            {
                this.Database.Trips.GetAll().Where(e => e.Trip_Title == trip.Trip_Title).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Destinations.Create(destination);
                this.Database.Dates_ranges.Create(dates_Ranges);
                this.Database.Trips.Create(trip);
                this.Database.Save();
            }
        }
        ////public int Authenticate(string username, string password)
        ////{
        ////    if (string.IsNullOrEmpty(username))
        ////    {
        ////        throw new Exception("Username is empty.");
        ////    }
        ////    else if (string.IsNullOrEmpty(password))
        ////    {
        ////        throw new Exception("Password is empty.");
        ////    }

        ////    var user = Database.Users.Find(u => u.Username == username).SingleOrDefault();
        ////    if (user == null)
        ////    {
        ////        throw new Exception("User with current name does not exist.");
        ////    }
        ////    else if (!VerifyHash(password, user.Hash))
        ////    {
        ////        throw new Exception("Invalid password.");
        ////    }

        ////    return user.Id;
        ////}

        public TripDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var trip = this.Database.Trips.Get(id.Value);
            if (trip == null)
            {
                throw new ValidationException("Trip with this ID was not found", string.Empty);
            }

            return new TripDTO
            {
                Trip_ID = trip.Trip_ID,
                Trip_Title = trip.Trip_Title,
                Description = trip.Description,
                Price = trip.Price,
                Date_ID = trip.Date_ID,
                Number_Of_People = trip.Number_Of_People,
                Destination_ID = trip.Destination_ID,
                Creator_ID = trip.Creator_ID,
            };
        }

        public IEnumerable<TripDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Trip, TripDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Trip>, List<TripDTO>>(this.Database.Trips.GetAll());
        }

        public void Dispose(int id)
        {
            var trip = this.Database.Trips.Get(id);
            if (trip != null)
            {
                this.Database.Trips.Delete(id);
                this.Database.Save();
            }
        }

        public int FindMaxIdDestination()
        {
            int max = this.Database.Destinations.MaxId();
            return max;
        }

        public int FindMaxIdDateRange()
        {
            int max = this.Database.Dates_ranges.MaxId();
            return max;
        }

        public IEnumerable<DestinationDTO> GetAllDist()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Destination, DestinationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Destination>, List<DestinationDTO>>(this.Database.Destinations.GetAll());
        }

        public IEnumerable<DatesRangeDTO> GetAllDateRanges()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dates_ranges, DatesRangeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dates_ranges>, List<DatesRangeDTO>>(this.Database.Dates_ranges.GetAll());
        }
        public IEnumerable<RightDTO> GetAllRights()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Right, RightDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Right>, List<RightDTO>>(this.Database.Rights.GetAll());
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(this.Database.Users.GetAll());
        }
    }
}
