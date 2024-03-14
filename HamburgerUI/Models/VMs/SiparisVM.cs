using HamburgerciMVC.DATA.Concrate;

namespace HamburgerUI.Models.VMs
{
    public class SiparisVM
    {

        public string UrunAdi { get; set; }

        public int Adet { get; set; }

        public double Fiyat { get; set; }

        public List<EkstraMalzeme> EkstraMalzemes { get; set; } 



    }
}
