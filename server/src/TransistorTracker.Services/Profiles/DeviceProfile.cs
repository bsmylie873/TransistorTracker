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
        CreateMap<CreateDeviceDto, Device>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now));
        CreateMap<UpdateDeviceDto, Device>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));
    }
}