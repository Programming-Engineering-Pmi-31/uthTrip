namespace UthTrip.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Interfaces;

    public interface IUserService
    {
        void CreateUser(UserDTO userDto);

        UserDTO GetById(int? id);

        UserDTO Get(int userAccountId);

        UserDTO GetByUsernamePassword(string username, string password);

        string GetFirstName(int userAccountId);

        IEnumerable<UserDTO> GetAll();

        void Dispose(int id);

        int FindMaxId();
    }
}
