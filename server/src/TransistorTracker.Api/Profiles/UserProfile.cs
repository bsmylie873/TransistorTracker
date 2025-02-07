using AutoMapper;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Users;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Users;

namespace TransistorTracker.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
    }
    
    private void ConfigureDtoToViewModel()
    {
        CreateMap<UserDto, UserViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateUserViewModel, CreateUserDto>();
        CreateMap<UpdateUserViewModel, UpdateUserDto>();
    }
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<UserDto>, PaginatedViewModel<UserViewModel>>();
    }
}