using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Ciudad

    {
        [Key]
        [Display(Name = "Codigo")]
        public int CiudadId { get; set; }

        [Display(Name = "Ciudad")]
        [Required]
        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string CiudadNombre { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }


    }
}