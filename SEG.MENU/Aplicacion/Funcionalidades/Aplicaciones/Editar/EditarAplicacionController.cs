using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarAplicacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarAplicacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarAplicacion(EditarAplicacionCommand command)
    {
        EditarAplicacionResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
