using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddSubClassesOfType
(this IServiceCollection services, Assembly assembly, Type type,
Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && type != p).ToList();
        foreach (Type? item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, type);
            }
        }
        return services;
    }

    public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(p => p.IsClass && !p.IsAbstract);
        foreach (Type? item in types)
        {
            var interfaces = item.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, item);
            }
        }
        return services;
    }
}
