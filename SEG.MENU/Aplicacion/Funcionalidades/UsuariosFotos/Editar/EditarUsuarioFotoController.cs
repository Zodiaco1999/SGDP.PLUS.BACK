using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarUsuarioFotoController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarUsuarioFotoController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarUsuarioFoto(EditarUsuarioFotoCommand command)
    {
        EditarUsuarioFotoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}