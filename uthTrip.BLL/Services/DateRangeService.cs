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
    public class DateRangeService : IDateRangeService
    {
        IUnitOfWork Database { get; set; }
        public int FindMaxId()
        {
            int max = this.Database.Dates_ranges.MaxId();
            return max;
        }
        public DateRangeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateDateRange(DatesRangeDTO dateRangeDto)
        {
            Dates_ranges dateRange = new Dates_ranges
            {
                Date_ID = dateRangeDto.Date_ID,
                Start_date = dateRangeDto.Start_date,
                End_date = dateRangeDto.End_date
            };
            Database.Dates_ranges.Create(dateRange);
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

        DatesRangeDTO IDateRangeService.GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not set.", "");
            var dateRange = Database.Dates_ranges.Get(id.Value);
            if (dateRange == null)
                throw new ValidationException("dateRange with this ID was not found", "");

            return new DatesRangeDTO
            {
                Date_ID = dateRange.Date_ID,
                Start_date = dateRange.Start_date,
                End_date = dateRange.End_date
            };
        }
        
        public IEnumerable<DatesRangeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dates_ranges, DatesRangeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dates_ranges>, List<DatesRangeDTO>>(Database.Dates_ranges.GetAll());
        }
        public void Dispose(int id)
        {
            var dateRange = Database.Dates_ranges.Get(id);
            if (dateRange != null)
            {
                Database.Dates_ranges.Delete(id);
                Database.Save();
            }
        }
    }
}

