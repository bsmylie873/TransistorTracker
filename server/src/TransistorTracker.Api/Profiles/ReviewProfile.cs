using AutoMapper;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Reviews;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Reviews;

namespace TransistorTracker.Api.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
        ConfigurePaginateMapping();
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
    
    private void ConfigurePaginateMapping()
    {
        CreateMap<PaginatedDto<ReviewDto>, PaginatedViewModel<ReviewViewModel>>();
    }
}