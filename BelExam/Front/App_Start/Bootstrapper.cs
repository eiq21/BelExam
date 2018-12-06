using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.Mvc;
using Client.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace Front.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure() {
            ConfigureAutofacContainer();
        }

        public static void ConfigureAutofacContainer() {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<NLogModule>();
            ConfigurationWCFContainer(containerBuilder);
        }

        public static void ConfigurationWCFContainer(ContainerBuilder containerBuilder) {
            //Registro Controllers
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Registrar proxies
            containerBuilder.Register(a => new ChannelFactory<Client.Contracts.IProductoService>("BasicHttpBinding_IProductoService"))
                .InstancePerLifetimeScope();
            containerBuilder.Register(a => new ChannelFactory<Client.Contracts.IPedidoService>("BasicHttpBinding_IPedidoService"))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProductoClient>().As<Client.Contracts.IProductoService>().UsingConstructor();
            containerBuilder.RegisterType<PedidoClient>().As<Client.Contracts.IPedidoService>().UsingConstructor();

            IContainer container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
          
        }

    }

    
}