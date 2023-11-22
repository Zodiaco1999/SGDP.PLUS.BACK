using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarTipoPersonaController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarTipoPersonaController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarTipoPersona(EditarTipoPersonaCommand command)
    {
        EditarTipoPersonaResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}