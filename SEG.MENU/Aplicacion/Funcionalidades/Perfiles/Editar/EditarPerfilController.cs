using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarPerfilController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarPerfilController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarPerfil(EditarPerfilCommand command)
    {
        EditarPerfilResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
