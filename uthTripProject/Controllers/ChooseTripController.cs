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
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;
    using UthTripProject.Models;

    public class ChooseTripController : Controller
    {
        private IRightsService rightsService;

        public ChooseTripController(IRightsService iserv)
        {
            this.rightsService = iserv;
        }

        public ActionResult ChooseTrip(string trip_id)
        {
            int rightsId = this.rightsService.FindMaxId() + 1;
            int roleId = this.rightsService.GetAllRoles().Where(e => e.Title == "Subscriber").Select(e => e.Role_ID).First();
            
            int userId = int.Parse(this.Session["User_ID"].ToString());
            int tripId = int.Parse(trip_id);
            RightDTO rightDTO = new RightDTO(rightsId, userId, roleId, tripId);
            try
            {
                this.rightsService.CreateRights(rightDTO);
                return this.RedirectToAction("../Home/MyTrips");
            }
            catch (ArgumentNullException ex)
            {
                this.ViewBag.ErrorMessage = "Ви вже обрали цю подорож.";
                return this.RedirectToAction($"../TripDetail/TripDetail/{trip_id}");
            }
        }
    }
}