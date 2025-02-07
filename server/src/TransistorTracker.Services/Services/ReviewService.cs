using AutoMapper;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Reviews;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Reviews;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class ReviewService : IReviewService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public ReviewService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService paginationService)
    {
        (_database, _mapper, _paginationService) = (database, mapper, paginationService);
    }
    
    public async Task<PaginatedDto<ReviewDto>> GetAllReviews(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;

        var reviewQuery = _database
            .Get<Review>()
            .Where(new ReviewsBySearchSpec(searchQuery));

        var reviews = _mapper
            .ProjectTo<ReviewDto>(reviewQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(reviews, pageSize, pageNumber);
    }

    public async Task<ReviewDto?> GetReviewById(int id)
    {
        var review = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));

        return await Task.FromResult(_mapper.Map<ReviewDto>(review) ?? null);
    }

    public async Task CreateReview(CreateReviewDto review)
    {
        var newReview = _mapper.Map<Review>(review);
        _database.Add(newReview);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdateReview(int id, UpdateReviewDto review)
    {
        var currentReview = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));

        if (currentReview == null) return false;

        _mapper.Map(review, currentReview);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteReview(int id)
    {
        var review = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));
        
        if (review == null) return await Task.FromResult(false);
        
        _database.Delete(review);
        await _database.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}