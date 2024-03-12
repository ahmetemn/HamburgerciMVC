using HamburgerciMVC.DATA.Abstract;
using HamburgerciMVC.DATA.Enums;

namespace HamburgerciMVC.DATA.Concrate
{
    public class Menu:BaseHamburger
    {


        public string MenuAdi { get; set; }

        public double MenuFiyat { get; set; }

        public string ImagePath { get; set; }


    }
}