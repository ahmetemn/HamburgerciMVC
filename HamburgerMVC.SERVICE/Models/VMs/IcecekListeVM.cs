using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerMVC.SERVICE.Models.VMs
{
	public class IcecekListeVM
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public double Fiyat { get; set; }

        public string ImagePath { get; set; }
        public SiparisBoyutu SiparisBoyutu { get; set; }
	}
}
