using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarUsuarioSesionController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarUsuarioSesionController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarUsuarioSesion(EditarUsuarioSesionCommand command)
    {
        EditarUsuarioSesionResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}