using Client.Entities.Custom;
using Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.Contracts
{
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        void Add(Producto model);

        [OperationContract]
        void Update(Producto model);

        [OperationContract]
        void Delete(Producto model);

        [OperationContract]
        Producto GetById(int id);

        [OperationContract]
        Producto[] GetAll();

        [OperationContract]
        IEnumerable<ProductoForGridView> GetAllForGridView();

        [OperationContract]
        IEnumerable<ProductoForGridView> Search(string search);

        [OperationContract]
        IEnumerable<ProductoForGridView> SearchWithSP(string search);
    }
}
