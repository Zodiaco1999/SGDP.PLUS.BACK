using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SEG.Comun.ContextAccesor;

public class ContextAccessor : IContextAccessor
{
    private IHttpContextAccessor _httpContextAccessor;

    public ContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId { get => _httpContextAccessor.HttpContext.User.Identity!.Name!; }
    public string UserName { get => _httpContextAccessor.HttpContext.User!.Identity!.Name!; }
    public string UserMail { get => throw new NotImplementedException(); }
    // public string ClientIP { get => $"{_httpContextAccessor.HttpContext.Connection.RemoteIpAddress} : {_httpContextAccessor.HttpContext.Connection.RemotePort}"; }
    public string ClientIP { get => $"{_httpContextAccessor.HttpContext.Connection.RemoteIpAddress}"; }
    public string Headers { get => JsonConvert.SerializeObject(_httpContextAccessor.HttpContext.Request.Headers); }
    public string SessionId { get => _httpContextAccessor.HttpContext.User.Claims.First(claim => claim.Type == "jti").Value; }

    public Guid AppId
    {
        get
        {
            if (_httpContextAccessor.HttpContext.Request.Headers["AppId"].Count > 0)
            {
                return Guid.Parse(_httpContextAccessor.HttpContext.Request.Headers["AppId"][0]!);
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
