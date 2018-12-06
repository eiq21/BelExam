using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
{
    public class Pedido : IExtensibleDataObject
    {
              
        public int PedidoID { get; set; }     
        public string Usuario { get; set; }     
        public int AnioCampania { get; set; }      
        public string Cuv { get; set; }     
        public int Cantidad { get; set; }      
        public virtual Producto Producto { get; set; }

        #region IExtensibleDataObject

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
