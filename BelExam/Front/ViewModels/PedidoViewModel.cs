using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.ViewModels
{
    public class PedidoViewModel
    {  
        public int PedidoID { get; set; }     
        public string Usuario { get; set; }     
        public int AnioCampania { get; set; }       
        public string Cuv { get; set; }       
        public int Cantidad { get; set; }
        public virtual ProductoViewModel Producto { get; set; }
    }
}