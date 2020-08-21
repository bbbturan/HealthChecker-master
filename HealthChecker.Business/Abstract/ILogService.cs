using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.Business.Abstract
{
    public interface ILogService
    {
        List<Log> GetAllLogs();

        Log GetLogById(int id);

        Log CreateLog(Log log);

        Log UpdateLog(Log log);

        bool DeleteLog(int id);

    }
}
