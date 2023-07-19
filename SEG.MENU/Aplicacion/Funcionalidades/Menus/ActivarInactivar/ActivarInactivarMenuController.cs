using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarMenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarMenuController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{menuId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarMenu(Guid menuId)
    {
        var response = await _mediator.Send(new ActivarInactivarMenuCommand(menuId));

        return Ok(response);
    }
}