using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthChecker.Entities
{
    public class TargetApp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Application Name")]
        public string Name { get; set; }
        [Display(Name="Application Url")]
        public string UrlString { get; set; }
        [Display(Name="Monitoring Interval")]
        public int Interval { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
