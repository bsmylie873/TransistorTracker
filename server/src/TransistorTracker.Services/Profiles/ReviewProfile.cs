using AutoMapper;
using TransistorTracker.Dal.Models;
using TransistorTracker.Server.DTOs.Reviews;

namespace TransistorTracker.Server.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Review, ReviewDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CreateReviewDto, Review>();
        CreateMap<UpdateReviewDto, Review>();
    }
}