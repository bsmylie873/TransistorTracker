using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Users;

public class UsersByNameSpec : Specification<User>
{
    private readonly string? _name;

    public UsersByNameSpec(string? name) => _name = name?.ToLower();

    public override Expression<Func<User, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_name)) return ShowAll;
        
        return x => x.Username.ToLower().StartsWith(_name);
    }
}