using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> ConsultarRespuestaLaftPorNit(string nit, bool actualiza, int pagina = 1, int registrosPorPagina = 20)
    {
        var response = await _mediator.Send(new ConsultarRespuestaLaftPorNitQuery(nit, actualiza, pagina, registrosPorPagina));

        return Ok(response);
    }  
}