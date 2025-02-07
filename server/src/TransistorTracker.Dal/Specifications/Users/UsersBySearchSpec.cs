using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Users;

public class UsersBySearchSpec : Specification<User>
{
    private readonly Specification<User> _spec;
    
    public UsersBySearchSpec(string? search) => _spec = 
        new UsersByNameSpec(search);
    
    public override Expression<Func<User, bool>> BuildExpression() =>
        _spec.BuildExpression();
}