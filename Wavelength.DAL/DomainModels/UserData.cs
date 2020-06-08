using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wavelength.DAL.DomainModels {
    public interface IUserData : IEntity {
        string Name { get; set; }
        byte Role { get; set; }
        
        int idGame { get; set; }
        GameData Game { get; set; }
    }

    public class UserData : _Base, IUserData {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte Role { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int idGame { get; set; }
        public virtual GameData Game { get; set; }
    }
}