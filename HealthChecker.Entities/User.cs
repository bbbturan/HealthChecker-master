using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthChecker.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Apps = new List<TargetApp>();
        }

        [Display(Name="First Name"), 
         StringLength(50)]
        public string Name { get; set; }
        [Display(Name="Last Name"), 
         StringLength(50)]
        public string Surname { get; set; }

        public ICollection<TargetApp> Apps { get; set; }
    }
}
