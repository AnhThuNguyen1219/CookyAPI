using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.UserEntity;

namespace CookyAPI.Services
{
    public interface IUsersService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        void UpdateUser(int id, User user);
        void AddUser(User user);
        void DelUser(int id);
        User GetLogin(Login user);

    }
}