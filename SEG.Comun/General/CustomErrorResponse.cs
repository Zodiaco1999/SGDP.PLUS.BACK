namespace SEG.Comun.General;

public class CustomErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public bool IsWarning { get; set; }
    public int StatusCode { get; set; }
    public bool CustomErrorWebApi { get { return true; } }
    public int Id { get; set; }
}
