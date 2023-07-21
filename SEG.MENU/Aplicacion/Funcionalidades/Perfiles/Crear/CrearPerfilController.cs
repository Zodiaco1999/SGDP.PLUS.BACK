using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Crear;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;

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
