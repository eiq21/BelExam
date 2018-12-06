using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
{
    public class Marca: IExtensibleDataObject
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }    
        public short MarcaID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }

        #region IExtensibleDataObject

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
