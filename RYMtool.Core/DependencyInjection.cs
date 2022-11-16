using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Services;

namespace RYMtool.Core;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection service)
    {
        var typesWithService  = Assembly
            .GetAssembly(typeof(DependencyInjection))
            ?.GetTypes().Where(t => 
                t.GetInterfaces()
                    .Any(i => 
                        i ==typeof(IService))).ToList();
        if (typesWithService != null)
        {
            var interfaces = typesWithService.Where(x => x.IsInterface).ToList();
            var classTypesWithService = typesWithService.Where(x => x.IsClass).ToList();
            foreach (var i in interfaces)
            {
                foreach (var c in classTypesWithService)
                {
                    if (i.IsAssignableFrom(c))
                    {
                        service.AddTransient(i,c);
                    }
                }
            }
        }
        return service;
    }
}