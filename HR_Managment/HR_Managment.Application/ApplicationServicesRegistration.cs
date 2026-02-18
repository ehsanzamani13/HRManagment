using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MapsterMapper;

namespace HR_Managment.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register Mapster configuration and services manually
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        //services.AddScoped<IMapper>();
    }
}
