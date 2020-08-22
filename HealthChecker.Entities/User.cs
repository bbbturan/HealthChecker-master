using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
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

        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["UserName"];
            Name = (string)jUser["Name"];
            Surname = (string)jUser["Surname"];
            PasswordHash = (string)jUser["PasswordHash"];
            Email = (string)jUser["Email"];
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
