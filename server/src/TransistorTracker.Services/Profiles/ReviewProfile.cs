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
        CreateMap<CreateReviewDto, Review>()
            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<UpdateReviewDto, Review>()
            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}