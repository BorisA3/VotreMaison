using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class PedidoDetalle
    {
        [Key]
        [Display(Name = "Codigo")]
        public int PedidoDetalleId { get; set; }

        public decimal PedidoDetalleSubTotal { get; set; }
        [Display(Name = "Pedido")]
       
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedidos { get; set; }
       
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Productos { get; set; }
    }
}