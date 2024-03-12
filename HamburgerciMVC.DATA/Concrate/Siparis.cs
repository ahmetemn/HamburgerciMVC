using HamburgerciMVC.DATA.Abstract;
using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Concrate
{
    public class Siparis:BaseHamburger
    {

        public SiparisBoyutu SiparisBoyutu { get; set; }

        public  int SiparisAdedi { get; set; }


        public  ICollection<Menu> Menus { get; set; }

        public ICollection<EkstraMalzeme> EkstraMalzemes { get; set; }


        public  string UserId { get; set; }
        public AppUser AppUser { get; set; }    

    }
}
