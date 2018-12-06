using Data.Core.Infrastructure;

namespace Tests.Proxies
{
    public class ClientInjectionClass : Disposable
    {
        public Client.Contracts.IPedidoService _pedidoProxy;
        public Client.Contracts.IProductoService _productoProxy;
        public ClientInjectionClass(Client.Contracts.IProductoService productoServiceProxy,
            Client.Contracts.IPedidoService pedidoServiceProxy)
        {
            this._pedidoProxy = pedidoServiceProxy;
            this._productoProxy = productoServiceProxy;
        }

        #region IDisposable
        protected override void DisposeCore()
        {
            base.DisposeCore();
            try
            {
                (_pedidoProxy as Client.Proxies.PedidoClient).CleanUp();

                (_productoProxy as Client.Proxies.ProductoClient).CleanUp();
            }
            catch
            {
                _pedidoProxy = null;
                _productoProxy = null;
            }
        }
        #endregion

        #region Methods

        public Client.Entities.Producto[] GetProducto()
        {
            return _productoProxy.GetAll();
        }

        public Client.Entities.Pedido[] GetPedido()
        {
            return _pedidoProxy.GetAll();
        }

        #endregion
    }

}
