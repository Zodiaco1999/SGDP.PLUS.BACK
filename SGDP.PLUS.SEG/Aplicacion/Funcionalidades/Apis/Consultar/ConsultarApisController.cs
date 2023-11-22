using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarApisController : ControllerBase
{
    public readonly IMediator _mediator;
    public ConsultarApisController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{aplicacionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarApis(Guid aplicacionId)
    {
        IEnumerable<ConsultarApisResponse> response = await _mediator.Send(new ConsultarApisQuery(aplicacionId));

        return Ok(response);
    }
}
