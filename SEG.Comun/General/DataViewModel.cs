namespace SEG.Comun.General;

public class DataViewModel<T>
{
    public DataViewModel()
    {
    }

    public DataViewModel(int page, int pageSize, int totalRecords)
    {
        Page = page;
        PageSize = pageSize;
        TotalRecords = totalRecords;
    }

    public List<T> Data { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalRecords { get; set; }
}
