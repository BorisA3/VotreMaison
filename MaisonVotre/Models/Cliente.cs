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

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int ClienteTelefono { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ClienteFchNaci { get; set; }

        public enum Sexo
        {
            Mujer,
            Hombre
        }

        [Display(Name = "Sexo")]
        [Required]
        public Sexo ClienteSexo { get; set; }

        [Display(Name = "Correo")]
        [Required]
        public string UsuarioEmail { get; set; }

        //[ForeignKey("Id")]
        //public ApplicationUser User { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }

}