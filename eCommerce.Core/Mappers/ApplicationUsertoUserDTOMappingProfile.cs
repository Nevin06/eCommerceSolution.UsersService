using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUsertoUserDTOMappingProfile : Profile // 102
{
    public ApplicationUsertoUserDTOMappingProfile() 
    {
        CreateMap<ApplicationUser, UserDTO>()
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}
