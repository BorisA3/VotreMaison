using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaisonVotre.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = "Codigo")]

        public int  ProductoId { get; set; }
        [Display(Name = "Producto")]
        [Required]
        [MaxLength(50, ErrorMessage = "El maximo permitido es 50")]
        [MinLength(2, ErrorMessage = "El minimo es de 2")]
        public string ProductoNombre { get; set; }
        [Display(Name = "Precio")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrecio { get; set; }
        [Display(Name = "Imagen")]
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }
       
        [Display(Name = "Ultima Compra")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "EL formato del campo debe ser una fecha.")]
        public DateTime ProductUltimaVenta { get; set; }

        [Display(Name = "Existencia")]
        [Required]
        public float ProductExistencia { get; set; }

        [Display(Name = "Producto Descripcion")]
        [Required]
        public string Productodescripcion { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categorias { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresas { get; set; }

        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }





    }
}