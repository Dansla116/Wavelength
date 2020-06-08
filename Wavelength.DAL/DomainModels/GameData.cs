using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wavelength.DAL.DomainModels {
    public interface IGameData : IEntity {
        string Code { get; set; }
        byte State { get; set; }
    }

    public class GameData : _Base, IGameData {
        [Required]
        public string Code { get; set; }
        
        [Required]
        public byte State { get; set; }
    }
}