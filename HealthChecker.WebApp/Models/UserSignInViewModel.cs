using System.ComponentModel.DataAnnotations;

namespace HealthChecker.WebApp.Models
{
    public class UserSignInViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }
    }
}
