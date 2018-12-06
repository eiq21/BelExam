using Autofac;
using Autofac.Integration.Wcf;
using Business.Services;
using Client.Proxies;
using NUnit.Framework;
using System;
using System.Linq;
using System.ServiceModel;
namespace Tests.Proxies
{
    [TestFixture]
    public class ProxiesTests
    {
        IContainer container = null;
        ServiceHost svcProductoHost = null;
        ServiceHost svcPedidoHost = null;
        Uri svcProductoServiceURI = new Uri("http://localhost:64337/ProductoService.svc");
        Uri svcPedidoServiceURI = new Uri("http://localhost:64337/PedidoService.svc");

        [SetUp]
        public void Setup()
        {
            try
            {
                container = Bootstrapper.BuildContainer();

                svcProductoHost = new ServiceHost(typeof(ProductoService), svcProductoServiceURI);
                svcPedidoHost = new ServiceHost(typeof(PedidoService), svcPedidoServiceURI);

                svcProductoHost.AddDependencyInjectionBehavior<Business.Services.Contracts.IProductoService>(container);
                svcPedidoHost.AddDependencyInjectionBehavior<Business.Services.Contracts.IPedidoService>(container);

               svcPedidoHost.Open();
                svcProductoHost.Open();
            }
            catch (Exception ex)
            {
                svcPedidoHost = null;
                svcProductoHost = null;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (svcPedidoHost != null && svcPedidoHost.State != CommunicationState.Closed)
                    svcPedidoHost.Close();

                if (svcPedidoHost != null && svcPedidoHost.State != CommunicationState.Closed)
                    svcPedidoHost.Close();
            }
            catch (Exception ex)
            {
                svcPedidoHost = null;
                svcPedidoHost = null;
            }
            finally
            {
                svcPedidoHost = null;
                svcPedidoHost = null;
            }
        }

        [Test]
        public void test_self_host_connection()
        {
            Assert.That(svcProductoHost.State, Is.EqualTo(CommunicationState.Opened));
            Assert.That(svcPedidoHost.State, Is.EqualTo(CommunicationState.Opened));
        }

        [Test]
        public void test_producto_proxy_is_injected()
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                Client.Contracts.IPedidoService proxy
                = container.Resolve<Client.Contracts.IPedidoService>();

                Assert.IsTrue(proxy is ProductoClient);
            }
        }

        [Test]
        public void test_pedido_proxy_is_injected()
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                Client.Contracts.IPedidoService proxy
                = container.Resolve<Client.Contracts.IPedidoService>();

                Assert.IsTrue(proxy is PedidoClient);
            }
        }

        

        [Test]
        public void test_constructor_injected_proxy()
        {
            ClientInjectionClass _testClass = null;

            using (var lifetime = container.BeginLifetimeScope())
            {

                using (_testClass = new ClientInjectionClass(container.Resolve<Client.Contracts.IProductoService>(),
                   container.Resolve<Client.Contracts.IPedidoService>()))
                {
                    {
                        Client.Entities.Producto[] _productos = _testClass.GetProducto();
                        Client.Entities.Pedido[] _pedidos = _testClass.GetPedido();

                        Assert.That(_productos.Count(), Is.EqualTo(1));
                        Assert.That(_pedidos.Count(), Is.EqualTo(1));
                    }
                }
            }

            Assert.That((_testClass._productoProxy as ProductoClient).State, Is.EqualTo(CommunicationState.Closed));
            Assert.That((_testClass._pedidoProxy as PedidoClient).State, Is.EqualTo(CommunicationState.Closed));
        }


        [Test]
        public void test_producto_proxy_getall()
        {
            Client.Contracts.IProductoService proxy;
            Client.Entities.Producto[] producto = null;

            using (var lifetime = container.BeginLifetimeScope())
            {
                proxy = container.Resolve<Client.Contracts.IProductoService>();

                producto = proxy.GetAll();
            }

            Assert.That(producto.Count(), Is.EqualTo(1));

            // Close connection
            if ((proxy as ProductoClient).State == CommunicationState.Opened)
                (proxy as ClientBase<Client.Contracts.IPedidoService>).Close();
        }

        [Test]
        public void test_validar() {
            Assert.AreEqual("a", "a", "same");
        }

    }
}
