using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Models.Dtos
{
    public class MenuCreateDTO
    {
        public string MenuAdi { get; set; }

        public double MenuFiyat { get; set; }

        public string Description { get; set; }

        public SiparisBoyutu SiparisBoyutu { get; set; } = SiparisBoyutu.Normal; 
        public string ImagePath { get; set; }

    }
}
