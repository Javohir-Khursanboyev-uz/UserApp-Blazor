namespace UserApp_Blazor.Service.Configurations;

public class PaginationMetaData
{
    public PaginationMetaData(int totalCount, PaginationParams @params)
    {
        TotalCount = totalCount;
        PageSize = @params.PageSize;
        CurrentPage = @params.PageIndex;
        TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
    }

    public int TotalCount { get; }
    public int PageSize { get; }
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}