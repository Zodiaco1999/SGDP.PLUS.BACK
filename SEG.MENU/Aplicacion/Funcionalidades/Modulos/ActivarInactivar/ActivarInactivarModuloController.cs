using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarModuloController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarModuloController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{moduloId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarModulo(Guid moduloId)
    {
        await _mediator.Send(new ActivarInactivarModuloCommand(moduloId));

        return Ok();
    }
}