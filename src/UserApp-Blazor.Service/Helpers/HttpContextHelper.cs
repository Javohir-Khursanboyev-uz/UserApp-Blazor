using Microsoft.AspNetCore.Http;

namespace UserApp_Blazor.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor ContextAccessor { get; set; }

    public static HttpContext HttpContext => ContextAccessor?.HttpContext;

    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;

    public static long UserId => HttpContext?.User?.FindFirst("Id")?.Value != null
        ? Convert.ToInt64(HttpContext.User.FindFirst("Id").Value)
        : 0;

    public static string UserPhone => HttpContext?.User?.FindFirst("Phone")?.Value;
}