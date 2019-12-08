
namespace uthTrip.BLL.DTO { 

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
    using UthTrip.BLL.DTO;

    internal class ImageEntity
    {
        public int id { get; set; }
        
        public string ImagePath { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }

        public UserDTO user;
    }
}
