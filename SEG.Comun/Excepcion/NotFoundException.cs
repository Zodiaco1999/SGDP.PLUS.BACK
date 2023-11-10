using System.Net;

namespace SGDP.PLUS.Comun.Excepcion
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string name, object key)
            : base($"No se encontro el registro asociado a \"{name}\" por el parametro ({key}).", "", (int)HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string message)
         : base(message, "", (int)HttpStatusCode.NotFound)
        {
        }
    }
}
