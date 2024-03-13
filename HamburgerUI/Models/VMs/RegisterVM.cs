using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HamburgerUI.Models.VMs
{
    public class RegisterVM
    {

        public string UserName { get; set; }



        [Required(ErrorMessage = "Email adı gereklidir.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }


        public  string  PhoneNumber { get; set; }

    }
}
