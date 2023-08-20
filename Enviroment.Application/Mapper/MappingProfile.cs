using AutoMapper;
using Enviroment.Application.Command.ClientCommand;
using Enviroment.Application.Command.LicenseCommand;
using Enviroment.Application.Response.ClientResponse;
using Enviroment.Application.Response.LicenseResponse;
using Enviroment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Licenses, LicenseResponse>().ReverseMap();
            CreateMap<Licenses, CreateLicenseCommand>().ReverseMap();
            CreateMap<Licenses, UpdateLicenseCommand>().ReverseMap();

            CreateMap<Clients, ClientResponse>().ReverseMap();
            CreateMap<Clients, CreateClientCommand>().ReverseMap();
            CreateMap<Clients, UpdateClientCommand>().ReverseMap();

        }
    }

}
