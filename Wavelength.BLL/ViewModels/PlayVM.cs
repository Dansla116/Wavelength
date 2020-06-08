using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.BLL.BusinessModels;

namespace Wavelength.BLL.Models {
    public class PlayVM {
        public Game Game { get; set; }
        public User LocalUser { get; set; }
        public List<User> Users { get; set; }
        public List<SelectOption> Roles { get; set; }
        public List<SelectOption> States { get; set; }
    }
}