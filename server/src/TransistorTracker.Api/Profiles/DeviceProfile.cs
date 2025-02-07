using AutoMapper;
using TransistorTracker.Api.ViewModels.Devices;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.DTOs.Pagination;

namespace TransistorTracker.Api.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
    }

    private void ConfigureDtoToViewModel()
    {
        CreateMap<DeviceDto, DeviceViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateDeviceViewModel, CreateDeviceDto>();
        CreateMap<UpdateDeviceViewModel, UpdateDeviceDto>();
    }
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<DeviceDto>, PaginatedViewModel<DeviceViewModel>>();
    }
}