using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Parts;

public class PartsByNameSpec : Specification<Part>
{
    private readonly string? _name;

    public PartsByNameSpec(string? name) => _name = name?.ToLower();

    public override Expression<Func<Part, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_name)) return ShowAll;
        
        return x => x.Name.ToLower().StartsWith(_name);
    }
}