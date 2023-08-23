using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarPaisController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarPaisController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{paisId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarPais(Guid paisId)
    {
        ActivarInactivarPaisResponse response = await _mediator.Send(new ActivarInactivarPaisCommand(paisId));

        return Ok(response);
    }
}