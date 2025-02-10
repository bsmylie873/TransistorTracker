using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Reviews;

public class ReviewsByRatingSpec : Specification<Review>
{
    private readonly string? _rating;

    public ReviewsByRatingSpec(string? rating) => _rating = rating;

    public override Expression<Func<Review, bool>> BuildExpression()
    {
        if (_rating == null)
        {
            return x => true; // Return all reviews if no rating filter
        }
        
        if (!int.TryParse(_rating, out var rating))
        {
            return x => false; // Return no reviews for invalid rating
        }
        
        if (rating is < 0 or > 10) // Adjust max rating based on your scale
        {
            return x => false; // Return no reviews for out-of-range rating
        }
        
        return x => x.Rating == rating;
    }
}