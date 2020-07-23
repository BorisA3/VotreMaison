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
        [Key]
        [Display(Name = "Codigo")]
        public int EmpresaId { get; set; }

        [Display(Name = "Empresa")]
        [Required]
        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string EmpresaNombre { get; set; }

        [Display(Name = "Imagen")]
        [Required]
        [DataType(DataType.ImageUrl)]
        public string EmpresaImagen { get; set; }

        [Display(Name = "Descripcion")]
        [Required]
        [MaxLength(200, ErrorMessage = "El maximo permitido es 200")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string EmpresaDescripcion { get; set; }

        [Display(Name = "Logo")]
        [Required]
        [DataType(DataType.ImageUrl)]
        public string EmpresaLogo { get; set; }

        public enum Tipo
        {
            Afiliada,
            Publicidad
        }
        [Display(Name = "Tipo")]
        [Required]
        public Tipo EmpresaTipo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        
        [ForeignKey("CiudadId")]
        public Ciudad Ciudades { get; set; }



    }
}