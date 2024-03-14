using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Models.VMs
{
    public class MenuGetAllVM
    {
        public int ID { get; set; }

        public string  Name { get; set; }


        public double MenuFiyat { get; set; }


        public string Description { get; set; }

        public string ImagePath { get; set; }
        public Status Status { get; set; }
    }
}
