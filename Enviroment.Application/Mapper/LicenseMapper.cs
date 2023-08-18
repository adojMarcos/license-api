﻿using AutoMapper;


namespace Enviroment.Application.Mapper
{
    public class LicenseMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
             });

            var mapper = config.CreateMapper();
            return mapper;  
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
