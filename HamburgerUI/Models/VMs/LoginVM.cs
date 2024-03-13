using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamburgerUI.Models.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email adı gereklidir.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}