using HealthChecker.DataAccess.Abstracts;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthChecker.DataAccess.Concretes
{
    public class UserRepository : IUserRepository
    {
        TargetAppRepository appRepo = new TargetAppRepository();

        public bool DeleteUser(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    var deletedUser = GetUserById(id);

                    //var appList = appRepo.GetAllTargetApps().Where(x => x.UserId == id).ToList();

                    //foreach (var item in appList)
                    //{
                    //    appRepo.DeleteApp(item.Id);
                    //}

                    if(deletedUser.Apps.Count != 0)
                    {
                        foreach(var app in deletedUser.Apps)
                        {
                            appRepo.DeleteApp(app.Id);
                        }
                    }
                    
                    dbContext.Users.Remove(deletedUser);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                using(var dbContext = new ApplicationContext())
                {
                    return dbContext.Users.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    return dbContext.Users.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User InsertUser(User user)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return user;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User UpdateUser(User user)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.Users.Update(user);
                    dbContext.SaveChanges();
                    return user;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
