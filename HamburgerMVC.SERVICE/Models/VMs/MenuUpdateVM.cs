using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Models.VMs
{
    public class MenuUpdateVM
    {
        public int ID { get; set; }

        public double MenuFiyati { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
