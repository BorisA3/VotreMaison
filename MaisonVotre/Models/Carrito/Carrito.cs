using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models.Carrito
{
    public class Carrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal
        {
            get { return Producto.ProductPrecio * Cantidad; }
        }
    }
}