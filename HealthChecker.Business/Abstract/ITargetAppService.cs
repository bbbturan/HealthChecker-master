using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.Business.Abstract
{
    public interface ITargetAppService
    {
        List<TargetApp> GetAllApps();

        TargetApp GetAppById(int id);

        TargetApp CreateApp(TargetApp app);

        TargetApp UpdateApp(TargetApp app);

        bool DeleteApp(int id);
    }
}
