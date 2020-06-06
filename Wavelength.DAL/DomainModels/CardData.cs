using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wavelength.DAL.DomainModels {
    public interface ICardData : IEntity {
        string Left { get; set; }
        string Right { get; set; }
        bool Advanced { get; set; }
    }

    public class CardData : _Base, ICardData {
        [Required]
        public string Left { get; set; }

        [Required]
        public string Right { get; set; }

        [Required]
        public bool Advanced { get; set; }
    }
}