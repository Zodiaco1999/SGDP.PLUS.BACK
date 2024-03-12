using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

[Route("api/[controller]")]
[ApiController]
public class ConsultarRespuestaLaftPorNitController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarRespuestaLaftPorNitController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarRespuestaLaftPorId(string nit, int pagina = 1, int registrosPorPagina = 20)
    {
        var response = await _mediator.Send(new ConsultarRespuestaLaftPorNitQuery(nit, pagina, registrosPorPagina));

        return Ok(response);
    }  
}