using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using UthTrip.DAL.Entities;
using UthTrip.BLL.Interfaces;
using uthTripProject.Models;
using UthTrip.BLL.DTO;
using AutoMapper;

namespace uthTripProject.Controllers
{
    public class ImageController : Controller
    {
        private IImageService imageService;

        public ImageController(IImageService iserv)
        {
            this.imageService = iserv;
        }

        public ActionResult Index()
        {
            IEnumerable<ImageDTO> imageDtos = this.imageService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImageDTO, ImageViewModel>()).CreateMapper();
            var images = mapper.Map<IEnumerable<ImageDTO>>(imageDtos);
            return this.View(images);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ImageViewModel image)
        {



            var imageDto = new ImageDTO(image.id, image.ImagePath, image.ImageFile);

            this.imageService.addImage(imageDto);
            return this.RedirectToAction("Home");
        }

    }
}