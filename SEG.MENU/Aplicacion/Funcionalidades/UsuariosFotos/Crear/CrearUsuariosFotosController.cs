using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearUsuariosFotosController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearUsuariosFotosController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearUsuarioFoto(CrearUsuariosFotosCommand command)
    {
        CrearUsuariosFotosResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}