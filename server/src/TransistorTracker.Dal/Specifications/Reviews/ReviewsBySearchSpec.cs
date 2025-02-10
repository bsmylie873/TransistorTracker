using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Reviews;

public class ReviewsBySearchSpec : Specification<Review>
{
    private readonly Specification<Review> _spec;
    
    public ReviewsBySearchSpec(string? search) => _spec = 
        new ReviewsByRatingSpec(search);
    
    public override Expression<Func<Review, bool>> BuildExpression() =>
        _spec.BuildExpression();
}