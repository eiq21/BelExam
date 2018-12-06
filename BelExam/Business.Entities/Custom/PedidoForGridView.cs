using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Custom
{
    [Serializable]
    [DataContract]
    public class PedidoForGridView : IExtensibleDataObject
    {
        public PedidoForGridView()
        {

        }
        [DataMember]
        public int PedidoID { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string NombreProducto { get; set; }
        [DataMember]
        public int AnioCampania { get; set; }
        [DataMember]
        public string Cuv { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal? Precio { get; set; }
        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
