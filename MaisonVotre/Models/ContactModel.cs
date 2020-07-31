﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class ContactModel
    {
        [Required, Display(Name = "Sender Name")]
        public string SenderName { get; set; }
        [Display(Name = "Sender Email"), EmailAddress]
        public string SenderEmail { get; set; }

        [Required]
        public string Message { get; set; }

        
    }
}