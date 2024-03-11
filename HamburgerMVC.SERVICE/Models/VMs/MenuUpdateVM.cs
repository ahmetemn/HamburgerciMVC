using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Models.VMs
{
    public class MenuUpdateVM
    {

        public int Id { get; set; }
        public string MenuAdi { get; set; }

        public double MenuFiyat { get; set; }

        public string ImagePath { get; set; }
    }
}
