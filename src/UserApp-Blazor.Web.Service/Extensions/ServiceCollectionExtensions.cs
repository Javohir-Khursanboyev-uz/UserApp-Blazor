using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserApp_Blazor.Web.Service.Services;

namespace UserApp_Blazor.Web.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["Api:Url"]!;
        services.AddHttpClient("ApiClient", client =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}