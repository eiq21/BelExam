using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities.Custom
{
    
    public class ProductoForGridView :IExtensibleDataObject
    {
        public ProductoForGridView()
        {
        }

      
        public int AnioCampania { get; set; }
     
        public string Cuv { get; set; }
       
        public short MarcaID { get; set; }
       
        public string MarcaDescripcion { get; set; }
      
        public decimal Precio { get; set; }
       
        public string Descripcion { get; set; }
      
        public string CodigoTipoOferta { get; set; }
        
        public string CodigoSAP { get; set; }
        
        public bool EstadoActivo { get; set; }

      
        public virtual MarcaForViewModel Marca { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}

