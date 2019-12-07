////using Microsoft.EntityFrameworkCore;
namespace UthTrip.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using UthTrip.BLL.DTO;
    using UthTrip.BLL.Infrastructure;
    using UthTrip.BLL.Interfaces;
    using UthTrip.DAL.EF;
    using UthTrip.DAL.Entities;
    ////using UthTrip.BLL.BusinessModels;
    using UthTrip.DAL.Interfaces;

    public class UserService : IUserService
    {
        public UserService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Users.MaxId();
            return max;
        }

        public int FindMaxIdBl()
        {
            int max = this.Database.Blocked_Users.MaxId();
            return max;
        }

        public void CreateUser(UserDTO userDto)
        {
            User user = new User
            {
                User_ID = userDto.User_ID,
                First_Name = userDto.First_Name,
                Last_Name = userDto.Last_Name,
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
                Birthday = userDto.Birthday,
                Photo_Url = userDto.Photo_Url,
                Info = userDto.Info,
            };
            try
            {
                this.Database.Users.GetAll().Where(e => e.Username == user.Username).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Users.Create(user);
                this.Database.Save();
            }
        }
        public void CreateBlocked(BlockedUsersDTO userDto)
        {
            Blocked_Users user = new Blocked_Users
            {
                User_ID = userDto.User_ID,
                Blocked_ID = userDto.Blocked_ID,
            };
            this.Database.Blocked_Users.Create(user);
            this.Database.Save();
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

        public string GetFirstName(int userAccountId)
        {
            var result = this.GetAllUsers()
                .Where(x => x.User_ID == userAccountId)
                .Select(x => x.First_Name)
                .FirstOrDefault();

            return result;
        }

        public UserDTO Get(int userAccountId)
        {
            var userAccount = this.GetAllUsers()
                .FirstOrDefault(x => x.User_ID == userAccountId);

            return userAccount;
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

        public UserDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var user = this.Database.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new UserDTO
            {
                User_ID = user.User_ID,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Info = user.Info,
                Birthday = user.Birthday,
                Photo_Url = user.Photo_Url,
            };
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(this.Database.Users.GetAll());
        }

        public IEnumerable<ReviewDTO> GetAllReviews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<ReviewDTO>>(this.Database.Reviews.GetAll());
        }

        public IEnumerable<TripDTO> GetAllTrips()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Trip, TripDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Trip>, List<TripDTO>>(this.Database.Trips.GetAll());
        }

        public IEnumerable<BlockedUsersDTO> GetAllBlocked()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Blocked_Users, BlockedUsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Blocked_Users>, List<BlockedUsersDTO>>(this.Database.Blocked_Users.GetAll());
        }

        public void Dispose(int id)
        {
            var user = this.Database.Users.Get(id);
            if (user != null)
            {
                this.Database.Users.Delete(id);
                this.Database.Save();
            }
        }
        public void DisposeBlocked(int id)
        {
            var user = this.Database.Blocked_Users.Get(id);
            if (user != null)
            {
                this.Database.Blocked_Users.Delete(id);
                this.Database.Save();
            }
        }

        public static string strKey = "U2A9/R*41FD412+4-123";

        public static string Encrypt(string strData)
        {
            string strValue = " ";
            if (!string.IsNullOrEmpty(strKey))
            {
                if (strKey.Length < 16)
                {
                    char c = "XXXXXXXXXXXXXXXX"[16];
                    strKey = strKey + strKey.Substring(0, 16 - strKey.Length);
                }

                if (strKey.Length > 16)
                {
                    strKey = strKey.Substring(0, 16);
                }

                // create encryption keys
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(strKey.Length - 8, 8));

                // convert data to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(strData);

                // encrypt 
                DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();

                // convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
            }
            else
            {
                strValue = strData;
            }

            return strValue;
        }




        public UserDTO GetByUsernamePassword(string username, string password)
        {
            try
            {
                var user = this.Database.Users.GetbyPass(username, Encrypt(password));
                return new UserDTO
                {
                    User_ID = user.User_ID,
                    First_Name = user.First_Name,
                    Last_Name = user.Last_Name,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    Info = user.Info,
                    Birthday = user.Birthday,
                    Photo_Url = user.Photo_Url,
                };
            }
            catch (System.NullReferenceException)
            {
                return null;
            }
        }

        private List<UserDTO> GetAllUsers()
        {
            DateTime somedate = new DateTime(2000, 07, 21);
            return new List<UserDTO>()
            {
            new UserDTO
                {
                    User_ID = 123,
                    First_Name = "Simon",
                    Last_Name = "Gilbert",
                    Username = "simongilbert",
                    Email = "simongilbert@com",
                    Password = "1111",
                    Birthday = somedate,
                    Photo_Url = "www",
                    Info = "some boy",
                },
            new UserDTO
                {
                    User_ID = 456,
                    First_Name = "Alexander",
                    Last_Name = "Hill",
                    Username = "alexhill",
                    Email = "alexhill@com",
                    Password = "1111",
                    Birthday = somedate,
                    Photo_Url = "www",
                    Info = "anpther boy",
                },
            };
        }
    }
}