using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Users;

namespace TransistorTracker.Server.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<User, UserDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateUserDto, User>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<UpdateUserDto, User>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}