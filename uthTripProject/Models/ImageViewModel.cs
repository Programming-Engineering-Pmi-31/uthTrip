
namespace uthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using UthTrip.BLL.DTO;

    public class ImageViewModel
    {
      public  ImageViewModel()
        {
        }

        public ImageViewModel(ImageDTO image)
        {
            this.id = image.id;
            this.ImagePath = image.ImagePath;
            this.ImageFile = image.ImageFile;
        }

        public int id { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}