using System.ComponentModel.DataAnnotations;

namespace ECommerceMvc.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adını giriniz!")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi giriniz!")]
        public string Password { get; set; }
    }
}
