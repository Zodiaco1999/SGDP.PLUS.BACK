using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearUsuarioSesionController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearUsuarioSesionController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearUsuarioSesion(CrearUsuarioSesionCommand command)
    {
        CrearUsuarioSesionResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}