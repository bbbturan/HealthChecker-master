using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HealthChecker.API.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [JsonProperty("PasswordHash")]
        public string PasswordHash { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad boş geçilemez.")]
        [JsonProperty("Name")] 
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad boş geçilemez.")]
        [JsonProperty("SurName")] 
        public string SurName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [JsonProperty("Email")] 
        public string Email { get; set; }
    }
}
