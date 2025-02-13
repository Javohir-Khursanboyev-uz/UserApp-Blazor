using UserApp_Blazor.Service.Helpers;

namespace UserApp_Blazor.WebApi.Controllers;

public static class ServiceCollection
{
    public static void InjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
    }
}
