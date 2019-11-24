using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UthTrip.BLL.Interfaces;
using UthTrip.BLL.DTO;


namespace UthTrip.BLL.Interfaces
{
    public interface ITripService
    {
        void CreateTrip(TripDTO tripDto, DestinationDTO destinationDTO, DatesRangeDTO datesRangeDTO);
        TripDTO GetById(int? id);
        IEnumerable<TripDTO> GetAll();
        IEnumerable<DestinationDTO> GetAllDist();
        IEnumerable<DatesRangeDTO> GetAllDateRanges();

        void Dispose(int id);
        int FindMaxId();
        int FindMaxIdDestination();
        int FindMaxIdDateRange();
        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
