using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarAplicacionesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetEntityQuery query)
    {
        DataViewModel<ConsultarAplicacionesResponse> resultado = await _mediator.Send(new ConsultarAplicacionesQuery(query));

        return Ok(resultado);
    }
}
