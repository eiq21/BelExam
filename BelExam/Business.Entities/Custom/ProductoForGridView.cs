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
    public class ProductoForGridView : IExtensibleDataObject
    {
        public ProductoForGridView()
        {
        }

        [DataMember]
        public int AnioCampania { get; set; }
        [DataMember]
        public string Cuv { get; set; }
        [DataMember]
        public short MarcaID { get; set; }
        [DataMember]
        public string MarcaDescripcion { get; set; }
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
        public virtual MarcaForViewModel Marca { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
