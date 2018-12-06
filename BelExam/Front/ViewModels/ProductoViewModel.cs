using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ViewModels
{
    public class ProductoViewModel
    {     
        public int AnioCampania { get; set; }       
        public string Cuv { get; set; }      
        public short MarcaID { get; set; }      
        public decimal Precio { get; set; }      
        public string Descripcion { get; set; }        
        public string CodigoTipoOferta { get; set; }       
        public string CodigoSAP { get; set; }        
        public bool EstadoActivo { get; set; }        
        public virtual MarcaViewModel Marca { get; set; }      
        public virtual ICollection<PedidoViewModel> Pedido { get; set; }
    }
}