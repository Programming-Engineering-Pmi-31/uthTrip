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

        void CreateBlocked(BlockedUsersDTO userDto);

        UserDTO GetById(int? id);

        UserDTO Get(int userAccountId);

        UserDTO GetByUsernamePassword(string username, string password);

        string GetFirstName(int userAccountId);

        IEnumerable<UserDTO> GetAll();

        IEnumerable<ReviewDTO> GetAllReviews();

        IEnumerable<TripDTO> GetAllTrips();

        IEnumerable<BlockedUsersDTO> GetAllBlocked();

        void Dispose(int id);
        void DisposeBlocked(int id);


        int FindMaxId();

        int FindMaxIdBl();
    }
}
