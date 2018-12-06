using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ViewModels
{
    public class MarcaViewModel
    {
        public int MarcaID { get; set; }
        public string Descripcion { get; set; }    
        public virtual List<ProductoViewModel> Producto { get; set; }
    }
}