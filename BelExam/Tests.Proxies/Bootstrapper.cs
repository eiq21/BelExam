using Autofac;
using Autofac.Integration.Wcf;
using Business.Services;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Moq.Language;
using System;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.Proxies;


namespace Tests.Proxies
{
    public static class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Registro de servicios

            builder.RegisterType<PedidoService>().As<Business.Services.Contracts.IPedidoService>();
            builder.RegisterType<ProductoService>().As<Business.Services.Contracts.IProductoService>();

            // Registro de proxies
            builder.Register(c => new ChannelFactory<Client.Contracts.IPedidoService>("BasicHttpBinding_IPedidoService"))
            .InstancePerLifetimeScope();
            builder.Register(c => new ChannelFactory<Client.Contracts.IProductoService>("BasicHttpBinding_IProductoService"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductoClient>().As<Client.Contracts.IProductoService>().UseWcfSafeRelease();
            builder.RegisterType<PedidoClient>().As<Client.Contracts.IPedidoService>().UseWcfSafeRelease();

            // Unit of Work

            var _unitOfWork = new Mock<IUnitOfWork>();
            builder.RegisterInstance(_unitOfWork.Object).As<IUnitOfWork>();

            // DbFactory
            var _dbFactory = new Mock<IDbFactory>();
            builder.RegisterInstance(_dbFactory.Object).As<IDbFactory>();

            //Repositories
            var _productoRepository = new Mock<IProductoRepository>();
            _productoRepository.Setup(x => x.GetAll()).Returns(new List<Business.Entities.Producto>()
                {
                    new Business.Entities.Producto() {
                         AnioCampania = 201805,
                         Cuv = "00006",
                         Marca = new Business.Entities.Marca {
                             MarcaID = 1,
                             Descripcion = "L'Bel"
                         },
                         Precio = 45.00M,
                         Descripcion = "LB Essential Demaquillador + SA Nocturne",
                         CodigoTipoOferta = "106",
                         CodigoSAP ="200093110",
                         EstadoActivo = true,
                         MarcaID = 1
                    }
                });
            builder.RegisterInstance(_productoRepository.Object).As<IProductoRepository>();

            var _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoRepository.Setup(x => x.GetAll())
                .Returns(new List<Business.Entities.Pedido>() {
                    new Business.Entities.Pedido {
                        PedidoID = 1,
                        Usuario ="VISITANTE",
                        AnioCampania = 201805,
                        Cuv = "00006",
                        Cantidad = 6
                    }
                });
            builder.RegisterInstance(_pedidoRepository.Object).As<IPedidoRepository>();

            builder.RegisterType<ClientInjectionClass>();


            // build container
            return builder.Build();
        }
    }
}
