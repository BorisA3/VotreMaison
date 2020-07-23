using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Pedido
    {
        [Key]
        [Display(Name = "Codigo")]
        public int PedidoId { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime PedidoFecha { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Clientes { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [MaxLength(200, ErrorMessage = "El maximo permitido es 200")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string PedidoDireccion { get; set; }

        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
        


    }
}