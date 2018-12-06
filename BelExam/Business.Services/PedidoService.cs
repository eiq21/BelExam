using Business.Entities;
using Business.Entities.Custom;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IUnitOfWork unitOfWork, IPedidoRepository pedidoRepository)
        {
            _unitOfWork = unitOfWork;
            _pedidoRepository = pedidoRepository;
        }
        public void Add(Pedido model)
        {
            _pedidoRepository.Add(model);
            _unitOfWork.Commit();
        }

        public void Delete(Pedido model)
        {
            _pedidoRepository.Delete(model);
            _unitOfWork.Commit();
        }

        public Pedido[] GetAll()
        {
            return _pedidoRepository.GetAll().ToArray();
        }

        public Pedido GetById(int id)
        {
            return _pedidoRepository.GetById(id);
        }

        public IEnumerable<PedidoForGridView> GetPedidoByClient(string client, int anioCampania)
        {
            var result = new List<PedidoForGridView>();
            result = _pedidoRepository.GetAll(x => x.Producto).Where(a => a.Usuario.ToUpper() == client.ToUpper() && a.AnioCampania == anioCampania)
                .Select(x => new PedidoForGridView
                {
                    PedidoID = x.PedidoID,
                    AnioCampania = x.AnioCampania,
                    Cuv = x.Cuv,
                    Usuario = x.Usuario,
                    Cantidad = x.Cantidad,
                    NombreProducto = x.Producto.Descripcion,
                    Precio = x.Producto.Precio
                }).ToList();

            return result.ToArray();
        }

        public void Update(Pedido model)
        {
            _pedidoRepository.Update(model);
            _unitOfWork.Commit();
        }
    }
}
