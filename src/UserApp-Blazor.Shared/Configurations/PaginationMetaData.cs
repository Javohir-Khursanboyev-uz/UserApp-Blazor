namespace UserApp_Blazor.Shared.Configurations;

public class PaginationMetaData
{
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}