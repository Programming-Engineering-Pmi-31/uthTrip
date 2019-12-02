namespace UthTripProject.Controllers
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

    public class TripController : Controller
    {
        private ITripService tripService;

        public TripController(ITripService iserv)
        {
            this.tripService = iserv;
        }

        public ActionResult Index()
        {
            IEnumerable<TripDTO> tripDtos = this.tripService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TripDTO, TripViewModel>()).CreateMapper();
            var trips = mapper.Map<IEnumerable<TripDTO>, List<UserViewModel>>(tripDtos);
            return this.View(trips);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            TripViewModel tripModel = new TripViewModel();
            return this.View(tripModel);
        }

        [HttpPost]
        public ActionResult Create(TripViewModel tripModel)
        {
            try
            {
                tripModel.Trip_ID = this.tripService.FindMaxId() + 1;
                tripModel.Destination_ID = this.tripService.FindMaxIdDestination() + 1;
                tripModel.Date_ID = this.tripService.FindMaxIdDateRange() + 1;
                var sessionUserId = int.Parse(this.Session["User_ID"].ToString());
                tripModel.Creator_ID = sessionUserId;

                var tripDto = new TripDTO(tripModel.Trip_ID, tripModel.Trip_Title, tripModel.Description, tripModel.Price, tripModel.Date_ID, tripModel.Number_Of_People, tripModel.Destination_ID, tripModel.Creator_ID);
                var destinationDto = new DestinationDTO(tripModel.Destination_ID, tripModel.Is_Abroad, tripModel.Country, tripModel.City);
                var dateDto = new DatesRangeDTO(tripModel.Date_ID, tripModel.Start_date, tripModel.End_date);
                this.tripService.CreateTrip(tripDto, destinationDto, dateDto);
                return this.RedirectToAction("TripDetail", "TripDetail", new { id = tripModel.Trip_ID });
            }
            catch (ArgumentNullException)
            {
                this.ViewBag.DuplicateMessage = "Подорож з цією назвою вже існує.";
                return this.View("Create");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                this.ModelState.Clear();
                this.ViewBag.DuplicateMessage = "Неправильне ім'я користувача або пароль.";

                return this.View("Create", tripModel);
            }
        }
    }
}