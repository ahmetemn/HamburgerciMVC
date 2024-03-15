using HamburgerciMVC.DATA.Concrate;
using HamburgerciMVC.REPO.Abstract;
using HamburgerciMVC.REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.REPO.ConcrateREPO
{
	public class IceceklerREPO : BaseHamburgerREPO<Icecek>, IIceceklerREPO
	{
		public IceceklerREPO(ApplicationContext context) : base(context)
		{
		}
	}
}
