using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(User user);

        User UpdateUser(User user);

        bool DeleteUser(int id);
    }
}
