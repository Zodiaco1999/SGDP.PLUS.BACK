namespace SGDP.PLUS.Comun.General;

public class BaseCustomException : System.Exception
{
    public int Code { get; }
    public string Description { get; }

    public bool IsWarning { get; }

    public BaseCustomException(string message, string description, int code, bool isWarning = false) : base(message)
    {
        Code = code;
        Description = description;
        IsWarning = isWarning;
    }
}
