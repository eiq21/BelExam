using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Configurations
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            HasKey(a => new { a.AnioCampania, a.Cuv });
            Property(a => a.MarcaID).IsRequired();
            Property(a => a.Precio).IsRequired().HasPrecision(12, 2);
            Property(a => a.Descripcion).IsRequired().HasMaxLength(500);
            Property(a => a.CodigoTipoOferta).IsRequired().HasMaxLength(6).HasColumnType("char");
            Property(a => a.CodigoSAP).IsRequired().HasMaxLength(12);
            Property(a => a.EstadoActivo).IsRequired();
            HasMany(e => e.Pedido).WithRequired(a => a.Producto).HasForeignKey(e => new { e.AnioCampania, e.Cuv });
            Ignore(a => a.ExtensionData);
        }
    }
}
