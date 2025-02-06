using AutoMapper;
using TransistorTracker.Api.ViewModels.Reviews;
using TransistorTracker.Server.DTOs.Reviews;

namespace TransistorTracker.Api.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
    }

    private void ConfigureDtoToViewModel()
    {
        CreateMap<ReviewDto, ReviewViewModel>();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateReviewViewModel, CreateReviewDto>();
        CreateMap<UpdateReviewViewModel, UpdateReviewDto>();
    }
}