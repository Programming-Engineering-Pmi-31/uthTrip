using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uthTrip.BLL.Interfaces;
using uthTrip.BLL.DTO;

namespace uthTrip.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);
        UserDTO GetById(int? id);


        UserDTO Get(int userAccountId);
        string GetFirstName(int userAccountId);
        UserDTO GetByUsernamePassword(string username, string password);
        IEnumerable<UserDTO> GetAll();
        void Dispose(int id);
        int FindMaxId();
        //int Authenticate(string username, string password);
        // void Update(User user, string password = null);
        //void Create(string username, string password);
    }
}
