using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Ciudad

    {
        public int CiudadId { get; set; }

        public string CiudadNombre { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }


    }
}