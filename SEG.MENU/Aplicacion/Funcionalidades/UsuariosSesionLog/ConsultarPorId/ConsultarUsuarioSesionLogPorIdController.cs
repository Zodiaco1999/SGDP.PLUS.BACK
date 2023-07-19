using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuarioSesionLogPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuarioSesionLogPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarioSesionLogPorId(Guid logId)
    {
        var response = await _mediator.Send(new ConsultarUsuarioSesionLogPorIdQuery(logId));

        return Ok(response);
    }
}