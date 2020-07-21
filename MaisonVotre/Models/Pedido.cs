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
        public int PedidoId { get; set; }

        public DateTime PedidoFecha { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        

        [ForeignKey("ClienteId")]
        public Cliente clientes { get; set; }

        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
        


    }
}