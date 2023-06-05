using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarPerfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarPerfilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarPerfiles(EditarPerfilesCommand command)
    {
        EditarPerfilesResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
