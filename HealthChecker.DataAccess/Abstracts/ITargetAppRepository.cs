using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.DataAccess.Abstracts
{
    public interface ITargetAppRepository
    {
        List<TargetApp> GetAllTargetApps();

        TargetApp GetAppById(int id);

        TargetApp InsertApp(TargetApp app);

        TargetApp UpdateApp(TargetApp app);

        bool DeleteApp(int id);
    }
}
