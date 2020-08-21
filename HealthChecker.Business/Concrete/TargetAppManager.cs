using HealthChecker.Business.Abstract;
using HealthChecker.DataAccess.Abstracts;
using HealthChecker.DataAccess.Concretes;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.Business.Concrete
{
    public class TargetAppManager : ITargetAppService
    {
        private ITargetAppRepository _appRepository;

        public TargetAppManager()
        {
            _appRepository = new TargetAppRepository();
        }

        public TargetApp CreateApp(TargetApp app)
        {
            return _appRepository.InsertApp(app);
        }

        public bool DeleteApp(int id)
        {
            return _appRepository.DeleteApp(id);
        }

        public List<TargetApp> GetAllApps()
        {
            return _appRepository.GetAllTargetApps();
        }

        public TargetApp GetAppById(int id)
        {
            return _appRepository.GetAppById(id);
        }

        public TargetApp UpdateApp(TargetApp app)
        {
            return _appRepository.UpdateApp(app);
        }
    }
}
