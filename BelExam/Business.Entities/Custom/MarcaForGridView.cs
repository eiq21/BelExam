using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Custom
{
    [DataContract]
    public class MarcaForViewModel : IExtensibleDataObject
    {
        public MarcaForViewModel()
        {

        }
        [DataMember]
        public short MarcaID { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
