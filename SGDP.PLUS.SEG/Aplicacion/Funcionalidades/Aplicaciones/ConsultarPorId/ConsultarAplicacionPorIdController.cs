using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarAplicacionPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarAplicacionPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{aplicacionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarAplicacionPorId(Guid aplicacionId)
    {
        var response = await _mediator.Send(new ConsultarAplicacionPorIdQuery(aplicacionId));

        return Ok(response);
    }
}
