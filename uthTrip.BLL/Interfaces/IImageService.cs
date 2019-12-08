

namespace UthTrip.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using uthTrip.BLL.DTO;
    using UthTrip.DAL.Entities;

    public interface IImageService
    {

        void addImage(UthTrip.DAL.Entities.ImageEntity image);
    }
}
