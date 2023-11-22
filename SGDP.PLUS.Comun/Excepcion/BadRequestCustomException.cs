using System.Net;

namespace SGDP.PLUS.Comun.Excepcion;

public class BadRequestCustomException : BaseCustomException
{
    public BadRequestCustomException(string message, Exception innerException) : base(message, innerException, (int)HttpStatusCode.BadRequest)
    {
    }
}

