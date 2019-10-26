using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.BLL.DTO;
using uthTrip.DAL.Entities;
//using uthTrip.BLL.BusinessModels;
using uthTrip.DAL.Interfaces;
using uthTrip.BLL.Infrastructure;
using uthTrip.BLL.Interfaces;
using AutoMapper;

namespace uthTrip.BLL.Services
{
    public class TripService : ITripService
    {

        IUnitOfWork Database { get; set; }
        public int FindMaxId()
        {
            int max = Database.Trips.MaxId();
            return max;
        }
        public TripService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateTrip(TripDTO tripDto)
        {
            Trip trip = new Trip
            {
                Trip_ID = tripDto.Trip_ID,
                Trip_Title=tripDto.Trip_Title,
                Description=tripDto.Description,
                Price=tripDto.Price,
                Date_ID=tripDto.Date_ID,
                Number_Of_People=tripDto.Number_Of_People,
                Destination_ID=tripDto.Destination_ID,
                Creator_ID =tripDto.Creator_ID
            };
            Database.Trips.Create(trip);
            Database.Save();
        }
        //public int Authenticate(string username, string password)
        //{
        //    if (string.IsNullOrEmpty(username))
        //    {
        //        throw new Exception("Username is empty.");
        //    }
        //    else if (string.IsNullOrEmpty(password))
        //    {
        //        throw new Exception("Password is empty.");
        //    }

        //    var user = Database.Users.Find(u => u.Username == username).SingleOrDefault();
        //    if (user == null)
        //    {
        //        throw new Exception("User with current name does not exist.");
        //    }
        //    else if (!VerifyHash(password, user.Hash))
        //    {
        //        throw new Exception("Invalid password.");
        //    }

        //    return user.Id;
        //}


        public TripDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not set.", "");
            var trip = Database.Trips.Get(id.Value);
            if (trip == null)
                throw new ValidationException("Trip with this ID was not found", "");

            return new TripDTO
            {
                Trip_ID = trip.Trip_ID,
                Trip_Title = trip.Trip_Title,
                Description = trip.Description,
                Price = trip.Price,
                Date_ID = trip.Date_ID,
                Number_Of_People = trip.Number_Of_People,
                Destination_ID = trip.Destination_ID,
                Creator_ID = trip.Creator_ID
            };
        }
        public IEnumerable<TripDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Trip, TripDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Trip>, List<TripDTO>>(Database.Trips.GetAll());
        }
        public void Dispose(int id)
        {
            var trip = Database.Trips.Get(id);
            if (trip != null)
            {
                Database.Trips.Delete(id);
                Database.Save();
            }
        }

    }
}
