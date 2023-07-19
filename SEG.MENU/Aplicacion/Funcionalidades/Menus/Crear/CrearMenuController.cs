using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearMenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearMenuController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearMenu(CrearMenuCommand command)
    {
        CrearMenuResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}