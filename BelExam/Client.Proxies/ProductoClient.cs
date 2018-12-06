using Client.Entities.Custom;
using Client.Contracts;
using Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.Proxies
{
    public class ProductoClient : ClientBase<IProductoService>, IProductoService
    {
        public void Add(Producto model)
        {
            Channel.Add(model);
        }

        public void Delete(Producto model)
        {
            Channel.Delete(model);
        }

        public Producto[] GetAll()
        {
            return Channel.GetAll();
        }

        public Producto GetById(int id)
        {
            return Channel.GetById(id);
        }

        public void Update(Producto model)
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

        public IEnumerable< ProductoForGridView> GetAllForGridView()
        {
            return Channel.GetAllForGridView();
        }

        public IEnumerable<ProductoForGridView> Search(string search)
        {
            return Channel.Search(search);
        }

        public IEnumerable<ProductoForGridView> SearchWithSP(string search)
        {
            return Channel.SearchWithSP(search);
        }
    }
}
