using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

[ApiController]
[Route("api/[controller]")]
public class CrearPerfilController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearPerfilController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearPerfil(CrearPerfilCommand command)
    {
        CrearPerfilResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
