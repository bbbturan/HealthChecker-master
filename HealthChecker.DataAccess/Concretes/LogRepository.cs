using HealthChecker.DataAccess.Abstracts;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthChecker.DataAccess.Concretes
{
    public class LogRepository : ILogRepository
    {
        public bool DeleteLog(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    Log deletedLog = GetLogById(id);
                    dbContext.Logs.Remove(deletedLog);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Log> GetAllLogs()
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    return dbContext.Logs.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Log GetLogById(int id)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    return dbContext.Logs.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Log InsertLog(Log log)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.Logs.Add(log);
                    dbContext.SaveChanges();
                    return log;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Log UpdateLog(Log log)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    dbContext.Logs.Update(log);
                    dbContext.SaveChanges();
                    return log;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
