using HealthChecker.DataAccess.Abstracts;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace HealthChecker.DataAccess.Concretes
{
    public class TargetAppRepository : ITargetAppRepository
    {
        public bool DeleteApp(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {

                    var deletedApp = GetAppById(id);
                    dbContext.TargetApps.Remove(deletedApp);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TargetApp> GetAllTargetApps()
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    return dbContext.TargetApps.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TargetApp GetAppById(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    return dbContext.TargetApps.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TargetApp InsertApp(TargetApp app)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.TargetApps.Add(app);
                    dbContext.SaveChanges();
                    return app;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TargetApp UpdateApp(TargetApp app)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.TargetApps.Update(app);
                    return app;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
