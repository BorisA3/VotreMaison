using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Codigo")]
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        [Required]
        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]

        public string ClienteNombre { get; set; }
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]

        public int ClienteTelefono { get; set; }
        [Display(Name = "Numero de identificacion")]

        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
     
        public string ClientIdentificationId { get; set; }

        public float ClienteEdad { get; set; }

        public string ClienteSexo { get; set; }


        public virtual ICollection<Pedido> Pedidos { get; set; }

    }







}