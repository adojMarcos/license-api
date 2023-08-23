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

            CreateMap<Clients, CreateClientCommand>()
                .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForPath(dest => dest.Neigborhood, opt => opt.MapFrom(src => src.Address.Neigborhood))
                .ForPath(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForPath(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForPath(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement))
                .ForPath(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForPath(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

            CreateMap<CreateClientCommand, Clients>()
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Neigborhood, opt => opt.MapFrom(src => src.Neigborhood))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.Complement, opt => opt.MapFrom(src => src.Complement))
                .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode));

            CreateMap<Clients, UpdateClientCommand>().ReverseMap()
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Neigborhood, opt => opt.MapFrom(src => src.Neigborhood))
                .ForPath(dest => dest.Address.Number, opt => opt.MapFrom(src => src.Number))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.Complement, opt => opt.MapFrom(src => src.Complement))
                .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode));

            CreateMap<UpdateClientCommand, Clients>().ReverseMap()
                .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForPath(dest => dest.Neigborhood, opt => opt.MapFrom(src => src.Address.Neigborhood))
                .ForPath(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForPath(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForPath(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement))
                .ForPath(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForPath(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode)); ;

        }
    }

}
