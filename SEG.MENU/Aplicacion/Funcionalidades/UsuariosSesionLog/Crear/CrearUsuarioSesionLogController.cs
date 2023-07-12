using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearUsuarioSesionLogController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearUsuarioSesionLogController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearUsuarioSesionLog(CrearUsuarioSesionLogCommand command)
    {
        CrearUsuarioSesionLogResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}