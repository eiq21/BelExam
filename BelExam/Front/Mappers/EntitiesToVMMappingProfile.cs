using AutoMapper;
using Business.Entities;
using Front.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Mappers
{
    public class EntitiesToVMMappingProfile : Profile
    {
        public override string ProfileName {
            get {
                return "EntitiesToVMMappingProfile";
            }
        }

        public EntitiesToVMMappingProfile()
        {
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<Producto, ProductoViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
        }
    }
}