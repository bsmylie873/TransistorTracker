using AutoMapper;
using TransistorTracker.Api.ViewModels.Devices;
using TransistorTracker.Server.DTOs.Devices;

namespace TransistorTracker.Api.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
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
}