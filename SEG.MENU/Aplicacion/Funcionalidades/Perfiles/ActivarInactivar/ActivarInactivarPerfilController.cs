using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarPerfilController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarPerfilController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarPerfil(Guid perfilId)
    {
        ActivarInactivarPerfilResponse response = await _mediator.Send(new ActivarInactivarPerfilCommand(perfilId));

        return Ok(response);
    }
}
