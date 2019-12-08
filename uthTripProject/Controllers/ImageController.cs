using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uthTrip.BLL.DTO;
using UthTrip.DAL.Entities;
using UthTrip.BLL.Interfaces;

namespace uthTripProject.Controllers
{
    public class ImageController : Controller
    {
        private IImageService imageService;

        public ImageController(IImageService iserv)
        {
            this.imageService = iserv;
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ImageEntity image)
        {
            this.imageService.addImage(image);
            return RedirectToAction("Home");
        }

    }
}