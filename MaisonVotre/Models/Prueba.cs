using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Prueba
    {
        [Key]
        public int PruebaId { get; set; }

        public string PruebaName { get; set; }

    }
}