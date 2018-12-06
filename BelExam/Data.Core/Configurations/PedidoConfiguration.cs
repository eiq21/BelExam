using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Configurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(a => a.PedidoID);
            Property(a => a.Usuario).IsRequired().HasMaxLength(50);
            Property(a => a.AnioCampania).IsRequired();
            Property(a => a.Cuv).IsRequired();
            Property(a => a.Cantidad).IsRequired();
            Ignore(a => a.ExtensionData);
        }
    }
}
