using System.ComponentModel.DataAnnotations;

namespace HealthChecker.WebApp.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string PasswordHash { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad boş geçilemez.")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad boş geçilemez.")]
        public string SurName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email boş geçilemez.")]
        public string Email { get; set; }
    }
}
