namespace SGDP.PLUS.Comun.Excepcion;

public class BaseCustomException : Exception
{
    public int Code { get; }
    public string Description { get; } = string.Empty;
    public bool IsWarning { get; }
    public Exception? Excepcion { get; set; }

    public BaseCustomException(string message, int code, bool isWarning = false) : base(message)
    {
        Code = code;
        IsWarning = isWarning;
    }

    public BaseCustomException(string message, string description, int code, bool isWarning = false) : base(message)
    {
        Code = code;
        Description = description;
        IsWarning = isWarning;
    }

    public BaseCustomException(string message, Exception innerException, int code, bool isWarning = false) : base(message, innerException)
    {
        Code = code;
        Excepcion = innerException;
        IsWarning = isWarning;
    }
}
