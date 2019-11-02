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
using uthTrip.BLL.Services;
using uthTrip.BLL.DTO;
using uthTrip.BLL.Infrastructure;

namespace uthTripProject.Controllers
{
    public class HomeController : Controller
    {
        ITripService tripService;

        public HomeController(ITripService iserv)
        {
            tripService = iserv;
        }
        public ActionResult StartPage()
        {

            return View(tripService.GetAll());
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}