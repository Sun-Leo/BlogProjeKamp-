using System.ComponentModel.DataAnnotations;

namespace BlogProjeKampı.Areas.Admin.Models
{
    public class LoginAdminViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Girin")]

        public string Password { get; set; }
    }
}
