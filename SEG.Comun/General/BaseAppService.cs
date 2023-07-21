using Microsoft.Extensions.Logging;
using SGDP.PLUS.Comun.ContextAccesor;

namespace SGDP.PLUS.Comun.General;

public class BaseAppService
{
    protected readonly ILogger<BaseAppService> Logger;
    protected readonly IContextAccessor ContextAccessor;

    public BaseAppService(IContextAccessor contextAccessor, ILoggerFactory loggerFactory)
    {
        ContextAccessor = contextAccessor;
        Logger = loggerFactory.CreateLogger<BaseAppService>();
    }
}
