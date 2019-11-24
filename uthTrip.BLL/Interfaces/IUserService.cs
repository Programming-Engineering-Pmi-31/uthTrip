using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UthTrip.BLL.Interfaces;
using UthTrip.BLL.DTO;

namespace UthTrip.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);
        UserDTO GetById(int? id);

         UserDTO GetByUsernamePassword(string username, string password);


        UserDTO Get(int userAccountId);
        string GetFirstName(int userAccountId);

        UserDTO GetByUsernamePassword(string username, string password);
        IEnumerable<UserDTO> GetAll();
        void Dispose(int id);
        int FindMaxId();
       
    }
}
