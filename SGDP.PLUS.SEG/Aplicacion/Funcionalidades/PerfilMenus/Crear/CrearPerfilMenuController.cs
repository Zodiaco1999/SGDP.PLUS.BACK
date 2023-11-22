using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;

[ApiController]
[Route("api/[controller]")]
public class CrearPerfilMenuController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearPerfilMenuController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearPerfilMenu(CrearPerfilMenuCommand command)
    {
        CrearPerfilMenuResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
