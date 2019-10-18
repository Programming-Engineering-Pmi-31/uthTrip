using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTripProject.Models;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using AutoMapper;
using uthTrip.BLL.Interfaces;
using uthTrip.BLL.DTO;
using uthTrip.BLL.Infrastructure;


namespace uthTripProject.Controllers
{
    public class TripController : Controller
    {
        ITripService tripService;
        IDestinationService destinationService;
        IDateRangeService dateRangeService;
        public TripController(ITripService serv)
        {
            tripService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<TripDTO> tripDtos = tripService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TripDTO, TripViewModel>()).CreateMapper();
            var trips = mapper.Map<IEnumerable<TripDTO>, List<UserViewModel>>(tripDtos);
            return View(trips);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            TripViewModel tripModel = new TripViewModel();
            return View(tripModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(TripViewModel tripModel)
        {
            try
            {
                //tripModel.Trip_ID = tripService.FindMaxId() + 1;
                //tripModel.Destination_ID = destinationService.FindMaxId() + 1;
                //tripModel.Date_ID = dateService.FindMaxId() + 1;
                //tripModel.Creator_ID = 0;
                var tripDto = new TripDTO(tripModel.Trip_ID, tripModel.Trip_Title, tripModel.Description, tripModel.Price, tripModel.Date_ID, tripModel.Number_Of_People, tripModel.Destination_ID, tripModel.Creator_ID);
                tripService.CreateTrip(tripDto);
                var destinationDto = new DestinationDTO(tripModel.Destination_ID,tripModel.Is_Abroad,tripModel.Country,tripModel.City);
                destinationService.CreateDestination(destinationDto);
                var dateDto = new DatesRangeDTO(tripModel.Date_ID, tripModel.Start_date, tripModel.End_date);
                dateRangeService.CreateDateRange(dateDto);
                dateRangeService.CreateDateRange(dateDto);
                ViewBag.SuccessMessage = "Successfull creation of trip.";
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                ModelState.Clear();
                ViewBag.DuplicateMessage = "Trip with this name already exists.";
                return View("Create", tripModel);

            }
            ModelState.Clear();
            return View("Create", new TripViewModel());
        }
    }
}