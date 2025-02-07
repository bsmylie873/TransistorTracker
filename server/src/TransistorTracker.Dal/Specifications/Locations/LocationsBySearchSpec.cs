using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Locations;

public class LocationsBySearchSpec : Specification<Location>
{
    private readonly Specification<Location> _spec;
    
    public LocationsBySearchSpec(string? search) => _spec = 
        new LocationsByNameSpec(search);
    
    public override Expression<Func<Location, bool>> BuildExpression() =>
        _spec.BuildExpression();
}