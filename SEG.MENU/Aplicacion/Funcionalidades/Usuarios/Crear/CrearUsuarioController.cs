using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearUsuarioController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearUsuario(CrearUsuarioCommand command)
    {
        CrearUsuarioResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}