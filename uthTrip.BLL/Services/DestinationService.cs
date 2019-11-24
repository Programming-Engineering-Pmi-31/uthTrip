using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UthTrip.BLL.DTO;
using UthTrip.DAL.Entities;
////using UthTrip.BLL.BusinessModels;
using UthTrip.DAL.Interfaces;
using UthTrip.BLL.Infrastructure;
using UthTrip.BLL.Interfaces;
using AutoMapper;

namespace UthTrip.BLL.Services
{
    public class DestinationService : IDestinationService
    {
        IUnitOfWork Database { get; set; }
        public int FindMaxId()
        {
            int max = Database.Destinations.MaxId();
            return max;
        }
        public DestinationService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateDestination(DestinationDTO destinationDto)
        {
            Destination destination = new Destination
            {
                Destination_ID = destinationDto.Destination_ID,
                Is_Abroad = destinationDto.Is_Abroad,
                Country = destinationDto.Country,
                City = destinationDto.City
            };
            Database.Destinations.Create(destination);
            Database.Save();
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


        public DestinationDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not set.", "");
            var destination = Database.Destinations.Get(id.Value);
            if (destination == null)
                throw new ValidationException("Destination with this ID was not found", "");

            return new DestinationDTO
            {
                Destination_ID = destination.Destination_ID,
                Is_Abroad = destination.Is_Abroad,
                Country = destination.Country,
                City = destination.City
            };
        }
        public IEnumerable<DestinationDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Destination, DestinationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Destination>, List<DestinationDTO>>(Database.Destinations.GetAll());
        }
        public void Dispose(int id)
        {
            var trip = Database.Destinations.Get(id);
            if (trip != null)
            {
                Database.Destinations.Delete(id);
                Database.Save();
            }
        }

    }
}
