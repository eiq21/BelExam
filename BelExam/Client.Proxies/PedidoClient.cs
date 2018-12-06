using Client.Contracts;
using Client.Entities;
using Client.Entities.Custom;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Client.Proxies
{
    public class PedidoClient : ClientBase<IPedidoService>, IPedidoService
    {
        public void Add(Pedido model)
        {
            Channel.Add(model);
        }

        public void Delete(Pedido model)
        {
            Channel.Update(model);
        }

        public Pedido[] GetAll()
        {
            return Channel.GetAll();
        }

        public Pedido GetById(int id)
        {
            return Channel.GetById(id);
        }

        public void Update(Pedido model)
        {
            Channel.Update(model);
        }
        public void CleanUp()
        {
            try
            {
                if (base.State != CommunicationState.Faulted)
                    base.Close();
                else
                    base.Abort();
            }
            catch (Exception ex)
            {
                base.Abort();
            }
        }

        public IEnumerable<PedidoForGridView> GetPedidoByClient(string client, int anioCampania)
        {
            return Channel.GetPedidoByClient(client, anioCampania);
        }
    }
}
