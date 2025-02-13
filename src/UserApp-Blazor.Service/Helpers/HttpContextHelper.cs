using Microsoft.AspNetCore.Http;

namespace UserApp_Blazor.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor ContextAccessor { get; set; }

    public static HttpContext HttpContext => ContextAccessor?.HttpContext;

    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
}