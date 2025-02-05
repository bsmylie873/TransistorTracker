using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Devices;

namespace TransistorTracker.Server.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Device, DeviceDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateDeviceDto, Device>();
        CreateMap<UpdateDeviceDto, Device>();
    }
}