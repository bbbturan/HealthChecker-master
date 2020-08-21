using HealthChecker.Business.Abstract;
using HealthChecker.DataAccess.Abstracts;
using HealthChecker.DataAccess.Concretes;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User user)
        {
            return _userRepository.InsertUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
