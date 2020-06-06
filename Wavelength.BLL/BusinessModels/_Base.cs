using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wavelength.BLL.BusinessModels {
    public class Base {
        public int id { get; set; }
        public int UserAdded { get; set; }
        public int UserUpdated { get; set; }
        public DateTime DateAdded {get;set;}
        public DateTime DateUpdated { get; set; }
    }
}