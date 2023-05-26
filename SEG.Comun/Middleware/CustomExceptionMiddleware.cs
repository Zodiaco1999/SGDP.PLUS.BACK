using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net;
using SEG.Comun.General;
using SEG.Comun.ContextAccesor;

namespace SEG.Comun.Middleware;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly IContextAccessor _contextAccessor;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger<HttpContext> logger, IContextAccessor contextAccessor)
    {
        _next = next;
        _logger = logger;
        _contextAccessor = contextAccessor;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            try
            {
                //context.Request.EnableBuffering();

                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

                context.Request.Body.Position = 0;

                var json = JsonConvert.SerializeObject(new { path = context.Request.Path.Value, userid = context.User.Identity.Name, method = context.Request.Method, remoteIp = $"{context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}", body });

                _logger.LogInformation("Invoke: {0}", JsonConvert.SerializeObject(json));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, "Error leyendo 'Request.Body'");
            }

            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            int idError = new Random().Next(100000, 999999);

            try
            {
                using (var reader = new StreamReader(context.Request.Body))
                {
                    var body = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", idError, ex.Message, "Error leyendo 'Request.Body'", context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
            }

            await HandleExceptionAsync(context, ex);

        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;

        var json = JsonConvert.SerializeObject(new { path = context.Request.Path.Value, userid = context.User.Identity.Name, method = context.Request.Method, remoteIp = $"{context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}" });

        CustomErrorResponse customError = new CustomErrorResponse();

        if (exception is DbUpdateException)
        {
            if (exception.InnerException is SqlException && ((SqlException)(exception).InnerException).Number == 547)
            {
                customError.StatusCode = (int)HttpStatusCode.BadRequest;
                customError.Message = "Validación";
                customError.Description = $"Se generó un conflicto con una restricción asociada a la entidad. No se pudo finalizar la transacción";
                customError.IsWarning = true;
                customError.Id = new Random().Next(100000, 999999);


                _logger.LogError(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                {
                    customError.StatusCode = (int)HttpStatusCode.InternalServerError;
                    customError.Message = "Ha surgido un error";
                    customError.Description = "Intente de nuevo, si el problema persiste contacte con soporte";
                    customError.Id = new Random().Next(100000, 999999);
                    customError.Detail = $"Código error: '{customError.Id}'";

                    _logger.LogError(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                    //_logger.LogError(exception, $"{customError.Id} - {customError.Message}. {json}");

                }
            }
            else if (exception is BaseCustomException customException)
            {
                customError.StatusCode = customException.Code;
                customError.Message = customException.Message;
                customError.Description = customException.Description;

                if (customException.IsWarning)
                {
                    _logger.LogWarning(customException, $"{customException.Description}. {json}");
                }
                else
                {
                    customError.Id = new Random().Next(100000, 999999);
                    customError.Detail = $"Código error: '{customError.Id}'";
                    //_logger.LogError(exception, $"{customError.Id} - {customError.Message}. {json}");
                    _logger.LogError(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                }
            }
            else if (exception is System.ComponentModel.DataAnnotations.ValidationException validationException)
            {
                customError.StatusCode = (int)HttpStatusCode.NotAcceptable;
                customError.Message = "Validación";
                customError.Description = validationException.Message;
                customError.IsWarning = true;

                //_logger.LogWarning(exception, json);
                _logger.LogWarning(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                //_logger.LogWarning(exception, "customErrorId {@customErrorId}. UserId {@userId}. Path {@path}. Method {@method}. RemoteIp {@remoteIp}", customError.Id, context.User.Identity.Name
                //    , context.Request.Path.Value, context.Request.Method, context.Connection.RemoteIpAddress);
            }
            else if (exception is ValidationException eValidationException)
            {
                customError.StatusCode = (int)HttpStatusCode.NotAcceptable;
                customError.Message = "Validación";
                customError.Description = eValidationException.Message;
                customError.IsWarning = true;

                //_logger.LogWarning(exception, json);
                _logger.LogWarning(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                //_logger.LogWarning(exception, "customErrorId {@customErrorId}. UserId {@userId}. Path {@path}. Method {@method}. RemoteIp {@remoteIp}", customError.Id, context.User.Identity.Name
                //    , context.Request.Path.Value, context.Request.Method, context.Connection.RemoteIpAddress);
            }
            else
            {
                customError.StatusCode = (int)HttpStatusCode.InternalServerError;
                customError.Message = "Ha surgido un error";
                customError.Description = "Intente de nuevo, si el problema persiste contacte con soporte";
                customError.Id = new Random().Next(100000, 999999);
                customError.Detail = $"Código error: '{customError.Id}'";

                //_logger.LogError(exception, "customErrorId {@customErrorId}. UserId {@userId}. Path {@path}. Method {@method}. RemoteIp {@remoteIp}", customError.Id, context.User.Identity.Name
                //    , context.Request.Path.Value, context.Request.Method, context.Connection.RemoteIpAddress);
                //_logger.LogError(exception, $"{customError.Id} - {customError.Message}. {json}");
                //_logger.LogError(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}", customError.Id, customError.Message, customError.Description, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
                _logger.LogError(exception, "CustomErrorId: {@CustomErrorId}. Message: {@Message}. Description: {@description}. Host: {@Host}. Path: {@Path}. UserId: {@UserId}. Method: {@Method}. RemoteIpAddress: {@RemoteIpAddress}",
                    customError.Id, exception.Message, exception.InnerException?.Message, context.Request.Host.Value, context.Request.Path.Value, context.User.Identity.Name, context.Request.Method, context.Connection.RemoteIpAddress.ToString());
            }

            response.ContentType = "application/json";
            //response.StatusCode = customError.StatusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(customError));
        }
    }
}