using HR_Managment.Application.Contracts.Infrastructure;
using HR_Managment.Application.Models;
using HR_Managment.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Managment.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IEmailSender,EmailSender>();

        return services;
    }
}