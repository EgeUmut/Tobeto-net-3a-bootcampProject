using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class CoreModuleExtensions
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddTransient<MssqlLogger>();
        services.AddTransient<MongoDbLogger>();
        services.AddMemoryCache();
        services.AddTransient<ICacheManager,MemoryCacheManager>();
        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        return services;
    }
}
