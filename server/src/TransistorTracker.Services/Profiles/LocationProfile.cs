using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Locations;

namespace TransistorTracker.Server.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Location, LocationDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateLocationDto, Location>();
        CreateMap<UpdateLocationDto, Location>();
    }
}