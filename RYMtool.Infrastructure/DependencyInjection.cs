using Microsoft.Extensions.DependencyInjection;
using RYMtool.Core.Interfaces;

namespace RYMtool.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        return service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}