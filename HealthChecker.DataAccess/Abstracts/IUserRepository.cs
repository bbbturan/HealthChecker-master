using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.DataAccess.Abstracts
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User InsertUser(User user);

        User UpdateUser(User user);

        bool DeleteUser(int id);
    }
}
