using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarDetalleLaftController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarDetalleLaftController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarDetalleLaft(string nit, DateTime fechaSolicitud)
    {
        var response = await _mediator.Send(new ConsultarDetalleLaftQuery(nit, fechaSolicitud));

        return Ok(response);
    }
}
