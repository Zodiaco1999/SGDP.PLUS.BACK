using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarPerfilMenusController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarPerfilMenusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarPerfilMenus(EditarPerfilMenusCommand command)
    {
        EditarPerfilMenusResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
