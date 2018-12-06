using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    [DataContract]
    public class Marca : IExtensibleDataObject
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }
        [DataMember]
        public short MarcaID { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public virtual ICollection<Producto> Producto { get; set; }
        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
