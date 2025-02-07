using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Devices;

public class DevicesBySearchSpec : Specification<Device>
{
    private readonly Specification<Device> _spec;
    
    public DevicesBySearchSpec(string? search) => _spec = 
        new DevicesByNameSpec(search)
            .Or(new DevicesByModelSpec(search));
    
    public override Expression<Func<Device, bool>> BuildExpression() =>
        _spec.BuildExpression();
}