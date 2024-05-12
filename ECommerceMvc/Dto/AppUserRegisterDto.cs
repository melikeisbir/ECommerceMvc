using System.ComponentModel.DataAnnotations;

namespace ECommerceMvc.Dto
{
    public class AppUserRegisterDto //sisteme girerken bilgileri aktaracak o bilgiler veri tabanına aktarılacak
    {
        [Display(Name = "Adınız")]
        [Required(ErrorMessage = "Adınızı boş geçemezsiniz.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadınız")]
        [Required(ErrorMessage = "Soyadınızı boş geçemezsiniz.")]
        public string LastName { get; set; }

        [Display(Name = "Kullanıcı Adınız")]
        [Required(ErrorMessage = "Kullanıcı adınızı boş geçemezsiniz.")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email boş geçemezsiniz.")]
        public string Email { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifreyi boş geçemezsiniz.")]
        public string Password { get; set; }
        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifreyi tekrar giriniz.")]
        public string ConfirmPassword { get; set; }
    }
}
