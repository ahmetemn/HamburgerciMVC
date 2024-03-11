using HamburgerciMVC.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Concrate
{
    public  class EkstraMalzeme:BaseHamburger
    {

        public string EkstraMalzemeName { get; set; }

        public double EkstraMalzemeFiyati  { get; set; }


        public  int SiparisId { get; set; }
        public  Siparis Siparis { get; set; }
    }
}
