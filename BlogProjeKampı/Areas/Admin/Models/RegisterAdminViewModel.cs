using System.ComponentModel.DataAnnotations;

namespace BlogProjeKampı.Areas.Admin.Models
{
    public class RegisterAdminViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz")]
        public string NameSurmane { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }
    }

}
