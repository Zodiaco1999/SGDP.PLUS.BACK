using Microsoft.Extensions.Logging;
using SEG.Comun.ContextAccesor;

namespace SEG.Comun.General;

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
