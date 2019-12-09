
namespace UthTrip.BLL.DTO { 

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
    using UthTrip.BLL.DTO;

    public class ImageDTO
    {

        public ImageDTO()
        {


        }

        public ImageDTO(int id, String ImagePath, HttpPostedFileWrapper ImageFile)
        {
            this.id = id;
            this.ImagePath = ImagePath;
            this.ImageFile = ImageFile;

        }

        public int id { get; set; }
        
        public string ImagePath { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }

        //public UserDTO user;
    }
}
