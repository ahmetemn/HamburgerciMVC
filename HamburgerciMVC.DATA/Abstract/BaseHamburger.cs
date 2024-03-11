using HamburgerciMVC.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.DATA.Abstract
{
    public abstract class BaseHamburger
    {

        public  int Id  { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;   

        public DateTime DeletedDate { get; set; }

        public DateTime? UpdatedDate { get; set; } = null;

        public Status Status { get; set; } = Status.Added; 
    }
}
