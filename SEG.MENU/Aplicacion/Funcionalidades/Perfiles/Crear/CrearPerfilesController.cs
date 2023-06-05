using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

[ApiController]
[Route("api/[controller]")]
public class CrearPerfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearPerfilesController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearPerfiles(CrearPerfilesCommand command)
    {
        CrearPerfilesResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
