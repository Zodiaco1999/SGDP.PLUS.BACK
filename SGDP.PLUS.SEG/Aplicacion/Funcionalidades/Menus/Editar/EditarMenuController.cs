using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarMenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarMenuController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarMenu(EditarMenuCommand command)
    {
        EditarMenuResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}