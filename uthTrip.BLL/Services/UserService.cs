﻿using System;
using uthTrip.BLL.DTO;
using uthTrip.DAL.Entities;
//using uthTrip.BLL.BusinessModels;
using uthTrip.DAL.Interfaces;
using uthTrip.BLL.Infrastructure;
using uthTrip.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using uthTrip.DAL.EF;

using AutoMapper;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace uthTrip.BLL.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork Database { get; set; }
        public int FindMaxId()
        {
            int max = Database.Users.MaxId();
            return max;
        }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public void CreateUser(UserDTO userDto)
        {
            User user = new User
            {
                User_ID=userDto.User_ID,
                First_Name = userDto.First_Name,
                Last_Name=userDto.Last_Name,
                Email=userDto.Email,
                Username=userDto.Username,
                Password=userDto.Password,
                Birthday=userDto.Birthday,
                Photo_Url=userDto.Photo_Url,
                Info=userDto.Info
            };
            Database.Users.Create(user);
            Database.Save();
        }
        

        public UserDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not set.", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("User with this ID was not found", "");

            return new UserDTO { User_ID=user.User_ID, First_Name = user.First_Name,Last_Name=user.Last_Name,
            Email=user.Email, Username=user.Username, Password=user.Password,Info=user.Info, Birthday=user.Birthday, Photo_Url=user.Photo_Url};
        }
        public IEnumerable<UserDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }
        public void Dispose(int id)
        {
            var user = Database.Users.Get(id);
            if (user != null)
            {
                Database.Users.Delete(id);
                Database.Save();
            }
        }

        public UserDTO GetByUsernamePassword(string username, string password)
        {
            try
            {
                var user = Database.Users.GetbyPass(username, password);
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
                    Photo_Url = user.Photo_Url
                };
            }
            catch (System.NullReferenceException)
            {
                return null;
            }
        }
            
        }
    }

