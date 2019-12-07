namespace UthTrip.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.DAL.Entities;
    ////using UthTrip.BLL.BusinessModels;
    using UthTrip.DAL.Interfaces;

    public class RightsService : IRightsService
    {
        public RightsService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        private IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Rights.MaxId();
            return max;
        }

        public void CreateRights(RightDTO rightsDto)
        {
            Right rights = new Right
            {
                Rights_ID = rightsDto.Rights_ID,
                Role_ID = rightsDto.Role_ID,
                Trip_ID = rightsDto.Trip_ID,
                User_ID = rightsDto.User_ID,

            };
            try
            {
                this.Database.Rights.GetAll().Where(e => e.Role_ID == rights.Role_ID && e.Trip_ID == rights.Trip_ID && e.User_ID == rights.User_ID).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Rights.Create(rights);
                this.Database.Save();
            }
        }

        ////public int Authenticate(string username, string password)
        ////{
        ////    if (string.IsNullOrEmpty(username))
        ////    {
        ////        throw new Exception("Username is empty.");
        ////    }
        ////    else if (string.IsNullOrEmpty(password))
        ////    {
        ////        throw new Exception("Password is empty.");
        ////    }

        ////    var user = Database.Users.Find(u => u.Username == username).SingleOrDefault();
        ////    if (user == null)
        ////    {
        ////        throw new Exception("User with current name does not exist.");
        ////    }
        ////    else if (!VerifyHash(password, user.Hash))
        ////    {
        ////        throw new Exception("Invalid password.");
        ////    }

        ////    return user.Id;
        ////}

        RightDTO IRightsService.GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var rights = this.Database.Rights.Get(id.Value);
            if (rights == null)
            {
                throw new ValidationException("rights with this ID was not found", string.Empty);
            }

            return new RightDTO
            {
                Rights_ID = rights.Rights_ID,
                Role_ID = rights.Role_ID,
                User_ID = rights.User_ID,
                Trip_ID = rights.Trip_ID,
            };
        }

        public IEnumerable<RightDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Right, RightDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Right>, List<RightDTO>>(this.Database.Rights.GetAll());
        }

        public void Dispose(int id)
        {
            var rights = this.Database.Rights.Get(id);
            if (rights != null)
            {
                this.Database.Rights.Delete(id);
                this.Database.Save();
            }
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Role>, List<RoleDTO>>(this.Database.Roles.GetAll());
        }
    }
}