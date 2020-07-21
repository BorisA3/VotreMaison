using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string CategoriaNombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }


    }
}