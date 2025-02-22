using AutoMapper;
using TransistorTracker.Api.ViewModels.Locations;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Locations;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Api.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
    }
    
    private void ConfigureDtoToViewModel()
    {
        CreateMap<LocationDto, LocationViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateLocationViewModel, CreateLocationDto>();
        CreateMap<UpdateLocationViewModel, UpdateLocationDto>();
    }
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<LocationDto>, PaginatedViewModel<LocationViewModel>>();
    }
}