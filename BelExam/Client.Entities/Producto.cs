using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
{
    public class Producto :IExtensibleDataObject
    {
        public Producto()
        {
            Pedido = new HashSet<Pedido>();
        }
     
        public int AnioCampania { get; set; }      
        public string Cuv { get; set; }      
        public short MarcaID { get; set; }      
        public decimal Precio { get; set; }      
        public string Descripcion { get; set; }     
        public string CodigoTipoOferta { get; set; }       
        public string CodigoSAP { get; set; }       
        public bool EstadoActivo { get; set; }       
        public virtual Marca Marca { get; set; }       
        public virtual ICollection<Pedido> Pedido { get; set; }

        #region IExtensibleDataObject

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
