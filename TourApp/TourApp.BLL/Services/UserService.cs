using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourApp.DAL.Context;
using TourApp.DAL.Interfaces;
using TourApp.DAL.Models;
using TourApp.DAL.Repositories;

namespace TourApp.BLL.Services
{
    public class UserService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IRepository<User> users;

        public UserService()
        {
            applicationContext = new ApplicationContext();

            users = new Repository<User>(applicationContext);
        }

        public bool IsLogined(string login, string password) =>
            users.Get(x => x.Email == login && x.Password == password).Any();
    }
}
