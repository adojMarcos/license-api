using AutoMapper;
using Enviroment.Application.Command.ClientCommand;
using Enviroment.Application.Command.LicenseCommand;
using Enviroment.Application.Response.ClientResponse;
using Enviroment.Application.Response.LicenseResponse;
using Enviroment.Core.Entities;

namespace Enviroment.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Licenses, LicenseResponse>().ReverseMap();
            CreateMap<Licenses, CreateLicenseCommand>().ReverseMap();
            CreateMap<Licenses, UpdateLicenseCommand>().ReverseMap();

            CreateMap<Clients, ClientResponse>().ReverseMap()
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Neigborhood, opt => opt.MapFrom(src => src.Neigborhood))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.Complement, opt => opt.MapFrom(src => src.Complement))
                .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode));

            CreateMap<Clients, CreateClientCommand>().ReverseMap()
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Neigborhood, opt => opt.MapFrom(src => src.Neigborhood))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.Complement, opt => opt.MapFrom(src => src.Complement))
                .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode));

            CreateMap<Clients, UpdateClientCommand>().ReverseMap();

        }
    }

}
