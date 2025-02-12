using Newtonsoft.Json;
using UserApp_Blazor.Service.Configurations;
using UserApp_Blazor.Service.Helpers;

namespace UserApp_Blazor.Service.Extensions;

public static class CollectionExtensions
{
    public static IEnumerable<T> ToPaginateAsEnumerable<T>(this IEnumerable<T> source, PaginationParams @params)
    {
        int totalCount = source.Count();

        //var json = JsonConvert.SerializeObject(new PaginationMetaData(totalCount, @params));

        //HttpContextHelper.ResponseHeaders.Remove("X-Pagination");
        //HttpContextHelper.ResponseHeaders?.Add("X-Pagination", json);

        return @params.PageIndex > 0 && @params.PageSize > 0
            ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : source;
    }
}