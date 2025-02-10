using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Reviews;

namespace TransistorTracker.Server.Interfaces;

public interface IReviewService
{
    Task<PaginatedDto<ReviewDto>> GetAllReviews(PaginationDto pagination);
    Task<ReviewDto?> GetReviewById(int id);
    Task CreateReview(CreateReviewDto review);
    Task<bool> UpdateReview(int id, UpdateReviewDto review);
    Task<bool> DeleteReview(int id);
}