using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Locations;

public class LocationsByNameSpec : Specification<Location>
{
    private readonly string? _name;

    public LocationsByNameSpec(string? name) => _name = name?.ToLower();

    public override Expression<Func<Location, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_name)) return ShowAll;
        
        return x => x.Name.ToLower().StartsWith(_name);
    }
}