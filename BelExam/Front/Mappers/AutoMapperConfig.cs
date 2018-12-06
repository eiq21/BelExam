using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Mappers
{
    public class AutoMapperConfig
    {
        public static void Configure() {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<VMToEntitiesMappingProfile>();
                cfg.AddProfile<EntitiesToVMMappingProfile>();
            });
        }
    }
}