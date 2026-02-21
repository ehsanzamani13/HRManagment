using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Managment.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register Mapster configuration and services manually
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);

        // Register Mapster IMapper implementation
        services.AddScoped<IMapper, ServiceMapper>();

        // Register MediatR using the configuration overload.
        // This matches the expected signature and registers handlers from the executing assembly.
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()
        ));
    }
}
