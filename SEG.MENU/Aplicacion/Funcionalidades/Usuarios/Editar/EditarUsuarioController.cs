using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarUsuarioController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarUsuario(EditarUsuarioCommand command)
    {
        EditarUsuarioResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}