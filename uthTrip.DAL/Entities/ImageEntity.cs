namespace UthTrip.DAL.Entities
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


  public partial class ImageEntity
    {
        public int id { get; set; }

        public string ImagePath { get; set; }


        //public virtual ICollection<User> users { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }

    }
}
