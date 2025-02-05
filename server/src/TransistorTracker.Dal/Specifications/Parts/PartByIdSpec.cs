using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Parts;

public class PartByIdSpec : Specification<Part>
{
    private readonly int _id;

    public PartByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Part, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}