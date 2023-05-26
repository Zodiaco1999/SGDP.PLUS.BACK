using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarAplicacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> EditarAplicaciones(EditarAplicacionesCommand command)
    {
        EditarAplicacionesResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
