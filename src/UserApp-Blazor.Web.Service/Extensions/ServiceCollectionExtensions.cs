using Microsoft.Extensions.Configuration;
using UserApp_Blazor.Web.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace UserApp_Blazor.Web.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["Api:Url"]!;
        services.AddHttpClient("ApiClient", client =>
        {
            client.BaseAddress = new Uri(apiUrl, UriKind.Absolute);
        });
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}