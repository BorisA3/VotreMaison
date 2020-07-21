using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Rols
    {
        [Display(Name = "Rol")]
        public string RolName { get; set; }

    }
}