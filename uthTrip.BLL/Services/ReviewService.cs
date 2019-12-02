////using Microsoft.EntityFrameworkCore;
namespace UthTrip.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    ////using UthTrip.BLL.BusinessModels;
    using UthTrip.DAL.Interfaces;

    public class ReviewService : IReviewService
    {
        public ReviewService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Reviews.MaxId();
            return max;
        }

        public void CreateReview(ReviewDTO reviewDTO)
        {
            Review review = new Review
            {
                Review_ID = reviewDTO.Review_ID,
                Writer_ID = reviewDTO.Writer_ID,
                Trip_ID = reviewDTO.Trip_ID,
                Review1 = reviewDTO.Review1,
                Mark = reviewDTO.Mark,

            };

            this.Database.Reviews.Create(review);
            this.Database.Save();
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<ReviewDTO>>(this.Database.Reviews.GetAll());
        }

    }
}