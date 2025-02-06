using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Reviews;
using TransistorTracker.Server.DTOs.Reviews;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class ReviewService : IReviewService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public ReviewService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<ReviewDto> GetAllReviews()
    {
        var reviewQuery = _database
            .Get<Review>();

        return _mapper
            .ProjectTo<ReviewDto>(reviewQuery)
            .ToList();
    }

    public ReviewDto? GetReviewById(int id)
    {
        var review = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));

        return _mapper.Map<ReviewDto>(review) ?? null;
    }

    public void CreateReview(CreateReviewDto review)
    {
        var newReview = _mapper.Map<Review>(review);
        _database.Add(newReview);
        _database.SaveChanges();
    }

    public bool UpdateReview(int id, UpdateReviewDto review)
    {
        var currentReview = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));

        if (currentReview == null) return false;

        _mapper.Map(review, currentReview);
        _database.SaveChanges();
        return true;
    }

    public bool DeleteReview(int id)
    {
        var review = _database
            .Get<Review>()
            .FirstOrDefault(new ReviewByIdSpec(id));
        
        if (review == null) return false;
        
        _database.Delete(review);
        _database.SaveChanges();
        return true;
    }
}