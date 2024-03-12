using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Concrate
{
    public class Hamburger
    {

        public string HamburgerAdi { get; set; }

        public  ICollection<EkstraMalzeme> EkstraMalzemes { get; set; } 

        public  double HamburgerFiyati { get; set; }
    }
}
