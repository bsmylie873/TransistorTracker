using AutoMapper;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Software;

namespace TransistorTracker.Api.Profiles;

public class SoftwareProfile : Profile
{
    public SoftwareProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
    }
    
    private void ConfigureDtoToViewModel()
    {
        CreateMap<SoftwareDto, SoftwareViewModel>();
        CreateMap<SoftwareCompatibilityDto, SoftwareCompatibilityViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateSoftwareViewModel, CreateSoftwareDto>();
        CreateMap<CreateSoftwareCompatibilityViewModel, CreateSoftwareCompatibilityDto>();
        CreateMap<UpdateSoftwareViewModel, UpdateSoftwareDto>();
        CreateMap<UpdateSoftwareCompatibilityViewModel, UpdateSoftwareCompatibilityDto>();
    }
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<SoftwareDto>, PaginatedViewModel<SoftwareViewModel>>();
        CreateMap<PaginatedDto<SoftwareCompatibilityDto>, PaginatedDto<SoftwareCompatibilityViewModel>>();
    }
}