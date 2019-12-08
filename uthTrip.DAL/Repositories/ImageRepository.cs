////using Microsoft.EntityFrameworkCore;


namespace UthTrip.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    using UthTrip.DAL.Interfaces;

    public class ImageRepository : IRepository<ImageEntity>
    {
        private UthTripContext db;


        public ImageRepository(UthTripContext context)
        {
            this.db = context;
        }

        public void Create(ImageEntity image)
        {
            this.db.ImageEntity.Add(image);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageEntity> Find(Func<ImageEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ImageEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImageEntity GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int MaxId()
        {
            throw new NotImplementedException();
        }

        public void Update(ImageEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
