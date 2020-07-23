using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Codigo")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        [Required]
        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string CategoriaNombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }


    }
}