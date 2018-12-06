using AutoMapper;
using Business.Entities;
using Front.ViewModels;

namespace Front.Mappers
{
    public class VMToEntitiesMappingProfile :Profile
    {
        public override string ProfileName {
            get {
                return "VMToEntitiesMappingProfile";
            }
        }

        public VMToEntitiesMappingProfile()
        {
            CreateMap<MarcaViewModel, Marca>();
            CreateMap<ProductoViewModel, Producto>();
            CreateMap<PedidoViewModel, Pedido>();
        }
    }
}