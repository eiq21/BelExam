using Business.Entities;
using Data.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IPedidoRepository : IRepository<Pedido> { }
}
