using UserApp_Blazor.Shared.Configurations;

namespace UserApp_Blazor.Shared.Models;

public class PaginatedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
    public PaginationMetaData Pagination { get; set; }
}