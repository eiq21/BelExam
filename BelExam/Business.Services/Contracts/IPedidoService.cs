using Business.Entities;
using Business.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Contracts
{
    [ServiceContract]
    public interface IPedidoService
    {
        [OperationContract]
        void Add(Pedido model);

        [OperationContract]
        void Update(Pedido model);

        [OperationContract]
        void Delete(Pedido model);

        [OperationContract]
        Pedido GetById(int id);

        [OperationContract]
        Pedido[] GetAll();

        [OperationContract]
        IEnumerable<PedidoForGridView> GetPedidoByClient(string client, int anioCampania);


    }
}
