using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    [DataContract]
    public class Pedido : IExtensibleDataObject
    {
        [DataMember]
        public int PedidoID { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public int AnioCampania { get; set; }
        [DataMember]
        public string Cuv { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public virtual Producto Producto { get; set; }

        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
