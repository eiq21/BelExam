using Business.Entities;
using Business.Entities.Custom;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IUnitOfWork unitOfWork, IProductoRepository productoRepository)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }
        public void Add(Producto model)
        {
            _productoRepository.Add(model);
            _unitOfWork.Commit();
        }

        public void Delete(Producto model)
        {
            _productoRepository.Delete(model);
            _unitOfWork.Commit();
        }

        public Producto[] GetAll()
        {
            return _productoRepository.GetAll().Where(x => x.AnioCampania == 201805).ToArray();
        }

        public IEnumerable<ProductoForGridView> GetAllForGridView()
        {
            var result = new List<ProductoForGridView>();
            result = _productoRepository.GetAll(x => x.Marca).Where(a => a.AnioCampania == 201805)
                .Select(x => new ProductoForGridView
                {
                    AnioCampania = x.AnioCampania,
                    Cuv = x.Cuv,
                    MarcaID = x.MarcaID,
                    MarcaDescripcion = x.Marca.Descripcion,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    CodigoTipoOferta = x.CodigoTipoOferta,
                    CodigoSAP = x.CodigoSAP,
                    EstadoActivo = x.EstadoActivo,
                    Marca = new MarcaForViewModel
                    {
                        MarcaID = x.Marca.MarcaID,
                        Descripcion = x.Marca.Descripcion
                    }
                }).ToList();

            return result;

        }

        public Producto GetById(int id)
        {
            return _productoRepository.GetById(id);
        }

        public IEnumerable<ProductoForGridView> Search(string search)
        {
            if (search == null || search == string.Empty)
                return null;

            var result = new List<ProductoForGridView>();
            result = _productoRepository.GetAll(x => x.Marca).Where(x => x.Descripcion.ToLower().Contains(search.ToLower()) && x.AnioCampania == 201805)
                .Select(x => new ProductoForGridView
                {
                    AnioCampania = x.AnioCampania,
                    Cuv = x.Cuv,
                    MarcaID = x.MarcaID,
                    MarcaDescripcion = x.Marca.Descripcion,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    CodigoTipoOferta = x.CodigoTipoOferta,
                    CodigoSAP = x.CodigoSAP,
                    EstadoActivo = x.EstadoActivo
                }).ToList();

            return result;
        }

        public IEnumerable<ProductoForGridView> SearchWithSP(string search)
        {



            var query = _productoRepository.SelectQuery("SP_PRODUCTO_SEARCH @pAnioCampania,@pProductoNombre",
                new SqlParameter("@pAnioCampania", 201805),
                new SqlParameter("@pProductoNombre", search)).ToList();

            var result = query.Select(x => new ProductoForGridView
            {
                AnioCampania = x.AnioCampania,
                Cuv = x.Cuv,
                MarcaID = x.MarcaID,
                MarcaDescripcion = x.Marca.Descripcion,
                Precio = x.Precio,
                Descripcion = x.Descripcion,

                CodigoTipoOferta = x.CodigoTipoOferta,
                CodigoSAP = x.CodigoSAP,
                EstadoActivo = x.EstadoActivo
            }).ToList();

            return result;
        }

        public void Update(Producto model)
        {
            _productoRepository.Update(model);
            _unitOfWork.Commit();
        }
    }
}
