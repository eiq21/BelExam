using Autofac;
using Business.Services;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Web
{
    /// <summary>
    /// Configuración y construcción de Autofac IOC contenedores
    /// </summary>
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Registro de servicios

            builder.RegisterType<PedidoService>().As<IPedidoService>();
            builder.RegisterType<ProductoService>().As<IProductoService>();

            // Registro de repositories y UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<ProductoRepository>().As<IProductoRepository>();
            builder.RegisterType<PedidoRepository>().As<IPedidoRepository>();

            // build container
            return builder.Build();
        }
    }
}