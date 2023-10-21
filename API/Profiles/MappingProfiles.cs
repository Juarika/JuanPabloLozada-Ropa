using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserWithRolDto>()
        .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Roles.FirstOrDefault().Name))
        .ReverseMap();

        CreateMap<Supplier, SupplierDto>().ReverseMap();
        CreateMap<Input, InputDto>().ReverseMap();
        CreateMap<Dress, DressDto>().ReverseMap();
        CreateMap<Orden, OrdenDto>().ReverseMap();
        CreateMap<Input, InputNameDto>().ReverseMap();
        CreateMap<ProtectionType, ProtectionTypeDto>()
        .ForMember(e => e.Dresses, opt => opt.MapFrom(e => e.Dresses))
        .ReverseMap();
        CreateMap<Supplier, SupplierDto>()
        .ForMember(e => e.Inputs, opt => opt.MapFrom(e => e.Inputs))
        .ReverseMap();
        CreateMap<Dress, DressWithTotalDto>()
            .ForMember(e => e.Inputs, opt => opt.MapFrom(e => e.Inputs))
            .ReverseMap();

    }
}