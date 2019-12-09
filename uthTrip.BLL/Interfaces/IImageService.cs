

namespace UthTrip.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.BLL.DTO;
    using UthTrip.DAL.Entities;

    public interface IImageService
    {

        IEnumerable<ImageDTO> GetAll();

        void addImage(ImageDTO image);
    }
}
