using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using UthTrip.BLL.DTO;
using UthTrip.BLL.Interfaces;
using UthTrip.DAL.Entities;
using UthTrip.DAL.Interfaces;

namespace uthTrip.BLL.Services
{
    class ImageService : IImageService
    {

        public ImageService()
        {
        }

        public ImageService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        private IUnitOfWork Database { get; set; }

        public IEnumerable<ImageDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImageEntity, ImageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ImageEntity>, List<ImageDTO>>(this.Database.ImageEntity.GetAll());
        }


        public void addImage(ImageDTO imageDTO)
        {

            ImageEntity image = new ImageEntity
            {
                id = imageDTO.id,
                ImagePath = imageDTO.ImagePath,
                ImageFile = imageDTO.ImageFile
            };
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileName);
            image.ImageFile.SaveAs(fileName);

            this.Database.ImageEntity.Create(image);
            this.Database.Save();

        }
    }
}
