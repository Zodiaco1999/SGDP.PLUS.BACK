using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;

[ApiController]
[Route("api/[controller]")]
public class CrearPerfilMenusController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearPerfilMenusController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearPerfilMenus(CrearPerfilMenusCommand command)
    {
        CrearPerfilMenusResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
