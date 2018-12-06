using Business.Entities;
using Data.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }       
    }

    public interface IProductoRepository : IRepository<Producto> {
        
    }
}
