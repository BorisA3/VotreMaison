using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        public string EmpresaNombre { get; set; }

        public string EmpresaImagenes { get; set; }

        public string EmpresaDescripcion { get; set; }

        public string EmpresaLogo { get; set; }

        public string EmpresaTipo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        
        [ForeignKey("CiudadId")]
        public Ciudad ciudades { get; set; }



    }
}