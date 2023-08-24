using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilMenusPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilMenusPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfilMenusPorId(Guid perfilId)
    {
        var response = await _mediator.Send(new ConsultarPerfilMenusPorIdQuery(perfilId));

        return Ok(response);
    }
}
