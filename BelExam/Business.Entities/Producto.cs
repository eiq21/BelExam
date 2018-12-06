using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    [DataContract]
    public class Producto : IExtensibleDataObject
    {
        public Producto()
        {
            Pedido = new HashSet<Pedido>();
        }

        [DataMember]
        public int AnioCampania { get; set; }
        [DataMember]
        public string Cuv { get; set; }
        [DataMember]
        public short MarcaID { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodigoTipoOferta { get; set; }
        [DataMember]
        public string CodigoSAP { get; set; }
        [DataMember]
        public bool EstadoActivo { get; set; }
        [DataMember]
        public virtual Marca Marca { get; set; }
        [DataMember]
        public virtual ICollection<Pedido> Pedido { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
