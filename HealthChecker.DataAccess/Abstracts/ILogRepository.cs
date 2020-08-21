using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.DataAccess.Abstracts
{
    public interface ILogRepository
    {
        List<Log> GetAllLogs();

        Log GetLogById(int id);

        Log InsertLog(Log log);

        Log UpdateLog(Log log);

        bool DeleteLog(int id);
    }
}
