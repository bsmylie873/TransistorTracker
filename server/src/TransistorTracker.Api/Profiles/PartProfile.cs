using AutoMapper;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Parts;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Parts;

namespace TransistorTracker.Api.Profiles;

public class PartProfile : Profile
{
    public PartProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
    }
    
    private void ConfigureDtoToViewModel()
    {
        CreateMap<PartDto, PartViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreatePartViewModel, CreatePartDto>();
        CreateMap<UpdatePartViewModel, UpdatePartDto>();
    }
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<PartDto>, PaginatedViewModel<PartViewModel>>();
    }
}