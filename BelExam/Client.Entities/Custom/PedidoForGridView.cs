using System.Runtime.Serialization;

namespace Client.Entities.Custom
{

    public class PedidoForGridView : IExtensibleDataObject
    {
      
        public int PedidoID { get; set; }
      
        public string Usuario { get; set; }     
        public string NombreProducto { get; set; }

        public int AnioCampania { get; set; }
       
        public string Cuv { get; set; }
       
        public int Cantidad { get; set; }
      
        public decimal? Precio { get; set; }   

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
