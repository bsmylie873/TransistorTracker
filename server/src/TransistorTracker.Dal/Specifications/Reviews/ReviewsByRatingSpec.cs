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
        int.TryParse(_rating, out var rating);
        return x => x.Rating == rating;
    }
}