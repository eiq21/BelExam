using Business.Entities;
using Data.Core.Configurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Core
{
    public class DIContext:DbContext
    {
        public DIContext() : base("CnxSQL")
        {
           
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        public virtual void Commit() {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MarcaConfiguration());
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
