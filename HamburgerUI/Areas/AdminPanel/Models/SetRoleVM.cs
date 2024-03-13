using HamburgerciMVC.DATA.Concrate;
using Microsoft.AspNetCore.Identity;

namespace HamburgerUI.Areas.AdminPanel.Models
{
    public class SetRoleVM
    {

        public List<AppRole>  Roles { get; set; }

        public AppUser AppUser { get; set; }

        public string Role { get; set; }
    }
}
