using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using uthTrip.BLL.DTO;
using UthTrip.BLL.Interfaces;
using UthTrip.DAL.Entities;
using UthTrip.DAL.Interfaces;

namespace uthTrip.BLL.Services
{
    class ImageService : IImageService
    {
        public ImageService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }


        public void addImage(UthTrip.DAL.Entities.ImageEntity image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileName);
            image.ImageFile.SaveAs(fileName);

            this.Database.ImageEntity.Create(image);
            this.Database.Save();

        }
    }
}
