using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace apiAgenciasBackend.Register
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntidadesToDtoProfile());
                cfg.ValidateInlineMaps = false;
                cfg.CreateMissingTypeMaps = true;
            });
        }
    }
}
