using HealthChecker.Business.Abstract;
using HealthChecker.DataAccess.Abstracts;
using HealthChecker.DataAccess.Concretes;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthChecker.Business.Concrete
{
    public class LogManager : ILogService
    {
        private ILogRepository _logRepository;

        public LogManager()
        {
            _logRepository = new LogRepository();
        }

        public Log CreateLog(Log log)
        {
            return _logRepository.InsertLog(log);
        }

        public bool DeleteLog(int id)
        {
            return _logRepository.DeleteLog(id);
        }

        public List<Log> GetAllLogs()
        {
            return _logRepository.GetAllLogs();
        }

        public Log GetLogById(int id)
        {
            return _logRepository.GetLogById(id);
        }

        public Log UpdateLog(Log log)
        {
            return _logRepository.UpdateLog(log);
        }

        public List<Log> GetUserLogs(string userId)
        {
            var logList = GetAllLogs().ToList();
            return logList.Where(x => x.UserId == userId).ToList();
        }
    }
}
