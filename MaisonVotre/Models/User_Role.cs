using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class User_Role
    {

        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Rol")]
        public string RolName { get; set; }
    }
}