using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Locations;

public class LocationByIdSpec : Specification<Location>
{
    private readonly int _id;

    public LocationByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Location, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}