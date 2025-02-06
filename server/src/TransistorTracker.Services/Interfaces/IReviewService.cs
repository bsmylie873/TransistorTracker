using TransistorTracker.Server.DTOs.Reviews;

namespace TransistorTracker.Server.Interfaces;

public interface IReviewService
{
    IList<ReviewDto> GetAllReviews();
    ReviewDto? GetReviewById(int id);
    void CreateReview(CreateReviewDto review);
    bool UpdateReview(int id, UpdateReviewDto review);
    bool DeleteReview(int id);
}