using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Reviews;

public class ReviewByIdSpec : Specification<Review>
{
    private readonly int _id;

    public ReviewByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Review, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}