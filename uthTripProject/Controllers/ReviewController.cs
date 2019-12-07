namespace uthTripProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using UthTripProject.Models;

    public class ReviewController : Controller
    {
        private IReviewService reviewService;

        private int tripId;

        public ReviewController(IReviewService iserv)
        {
            this.reviewService = iserv;
        }

        [HttpGet]
        public ActionResult WriteReview(int? id)
        {
            if (this.Session["User_ID"] == null)
            {
                return this.RedirectToAction("../User/Login");
            }
            else
            {
                this.tripId = (int)id;
                ReviewViewModel reviewModel = new ReviewViewModel();
                return this.View(reviewModel);
            }
        }

        [HttpPost]
        public ActionResult WriteReview(int id, ReviewViewModel reviewViewModel)
        {
            ////TO DO: change this
            reviewViewModel.Review_ID = this.reviewService.FindMaxId()+1;
            reviewViewModel.Writer_ID = int.Parse(this.Session["User_ID"].ToString());
            reviewViewModel.Trip_ID = id;

            var reviewDto = new ReviewDTO(reviewViewModel.Review_ID, reviewViewModel.Writer_ID, reviewViewModel.Trip_ID, reviewViewModel.Review1, reviewViewModel.Mark);
            this.reviewService.CreateReview(reviewDto);

            int creator_id = this.reviewService.GetAllTrips().Where(t => t.Trip_ID == id).Select(t => t.Creator_ID).FirstOrDefault();
            return this.RedirectToAction($"../User/UserProfile/{creator_id}");
        }
    }
}