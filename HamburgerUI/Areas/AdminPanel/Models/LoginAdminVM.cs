using System.ComponentModel.DataAnnotations;

namespace HamburgerUI.Areas.AdminPanel.Models
{
    public class LoginAdminVM
    {


        public string UserName { get; set; }


        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
