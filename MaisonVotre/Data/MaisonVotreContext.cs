﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaisonVotre.Data
{
    public class MaisonVotreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MaisonVotreContext() : base("name=MaisonVotreContext")
        {
        }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Ciudad> Ciudads { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.PedidoDetalle> PedidoDetalles { get; set; }

        public System.Data.Entity.DbSet<MaisonVotre.Models.Producto> Productoes { get; set; }

    }
}
