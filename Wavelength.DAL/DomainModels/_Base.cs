using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wavelength.DAL.DomainModels {
    public interface IEntity {
        int id { get; set; }
        int UserAdded { get; set; }
        int UserUpdated { get; set; }
        DateTime DateAdded { get; set; }
        DateTime DateUpdated { get; set; }
    }

    public class _Base : IEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int UserAdded { get; set; }

        [Required]
        public int UserUpdated { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
    }
}