using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareByNameSpec : Specification<Models.Software>
{
    private readonly string? _name;

    public SoftwareByNameSpec(string? name) => _name = name?.ToLower();

    public override Expression<Func<Models.Software, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_name)) return ShowAll;
        
        return x => x.Name.ToLower().StartsWith(_name);
    }
}