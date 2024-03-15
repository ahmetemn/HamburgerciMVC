using HamburgerciMVC.DATA.Abstract;
using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Concrate
{
    public  class Icecek:BaseHamburger
    {

        public string  IcecekAdi { get; set; }


        public double Fiyat { get; set; }
        public string ImagePath { get; set; }
        public SiparisBoyutu SiparisBoyutu { get; set; }

    }
}
