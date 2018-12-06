using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities.Custom
{
  
    public class MarcaForViewModel : IExtensibleDataObject
    {
        public MarcaForViewModel()
        {

        }
     
        public short MarcaID { get; set; }
      
        public string Descripcion { get; set; }
        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
