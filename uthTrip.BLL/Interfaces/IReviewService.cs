namespace UthTrip.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Interfaces;

    public interface IReviewService
    {
        void CreateReview(ReviewDTO reviewDTO);

        IEnumerable<ReviewDTO> GetAll();

        IEnumerable<TripDTO> GetAllTrips();

        int FindMaxId();
    }
}
