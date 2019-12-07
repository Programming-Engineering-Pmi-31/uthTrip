namespace UthTrip.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Interfaces;

    public interface IRightsService
    {
        void CreateRights(RightDTO rightDto);

        RightDTO GetById(int? id);

        IEnumerable<RightDTO> GetAll();

        void Dispose(int id);

        int FindMaxId();

        IEnumerable<RoleDTO> GetAllRoles();
        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
