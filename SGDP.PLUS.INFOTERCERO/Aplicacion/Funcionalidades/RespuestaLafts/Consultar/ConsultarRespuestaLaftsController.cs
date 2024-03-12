using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarRespuestaLaftsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarRespuestaLaftsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarRespuestaLafts()
    {
        DataViewModel<ConsultarRespuestaLaftsResponse> response = await _mediator.Send(new ConsultarRespuestaLaftsQuery());

        return Ok(response);
    }
}