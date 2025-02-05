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
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}