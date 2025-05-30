namespace e_Bazaar.Client.Common;
public class PagedList<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
