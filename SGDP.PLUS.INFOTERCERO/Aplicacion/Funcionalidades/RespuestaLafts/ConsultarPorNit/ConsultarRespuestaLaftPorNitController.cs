using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarRespuestaLaftPorNitController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarRespuestaLaftPorNitController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarRespuestaLaftPorNit([FromQuery] GetEntityQuery query, string nit, bool actualiza)
    {
        var response = await _mediator.Send(new ConsultarRespuestaLaftPorNitQuery(query, nit, actualiza));

        return Ok(response);
    }  
}