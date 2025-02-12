using Newtonsoft.Json;
using UserApp_Blazor.Service.Configurations;
using UserApp_Blazor.Service.Helpers;

namespace UserApp_Blazor.Service.Extensions;

public static class CollectionExtensions
{
    public static (IEnumerable<T>, PaginationMetaData) ToPaginateAsEnumerable<T>(this IEnumerable<T> source, PaginationParams @params)
    {
        int totalCount = source.Count();
        var metaData = new PaginationMetaData(totalCount, @params);

        var paginatedData = @params.PageIndex > 0 && @params.PageSize > 0
            ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : source;

        return (paginatedData, metaData);
    }
}