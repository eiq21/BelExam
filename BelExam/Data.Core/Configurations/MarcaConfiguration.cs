using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Configurations
{
    public class MarcaConfiguration : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            HasKey(a => a.MarcaID);
            Property(a => a.Descripcion).IsRequired().HasMaxLength(20);
            Ignore(a => a.ExtensionData);
        }
    }
}
