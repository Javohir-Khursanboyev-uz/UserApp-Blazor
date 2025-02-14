using Newtonsoft.Json;
using UserApp_Blazor.Service.Helpers;
using UserApp_Blazor.Shared.Configurations;

namespace UserApp_Blazor.Service.Extensions;

public static class CollectionExtensions
{
    public static IEnumerable<T> ToPaginateAsEnumerable<T>(this IEnumerable<T> source, PaginationParams @params)
    {
        int totalCount = source.Count();

        var paginationMetaData = new PaginationMetaData();
        paginationMetaData.TotalPages = Convert.ToInt32(Math.Ceiling(totalCount / (decimal)@params.PageSize));
        paginationMetaData.CurrentPage = @params.PageIndex;
        paginationMetaData.HasPrevious = @params.PageIndex > 1;
        paginationMetaData.HasNext = @params.PageIndex < Convert.ToInt32(Math.Ceiling(totalCount / (decimal)@params.PageSize));

        var json = JsonConvert.SerializeObject(paginationMetaData);

        HttpContextHelper.ResponseHeaders.Remove("X-Pagination");
        HttpContextHelper.ResponseHeaders?.Add("X-Pagination", json);

        return @params.PageIndex > 0 && @params.PageSize > 0
            ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : source;
    }
}