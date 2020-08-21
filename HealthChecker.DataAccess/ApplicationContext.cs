using HealthChecker.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChecker.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-B601HFRF\\DBKURS1; Database=HealthCheckerDb; Trusted_Connection=True");
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<TargetApp> TargetApps { get; set; }
    }
}
