using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarIlicitosRespuestaPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarIlicitosRespuestaPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarIlicitosRespuestaPorId(Guid respuestaLaftId, int pagina = 1, int registrosPorPagina = 10, string ordenarPor = "ConsultaRealizada", bool ordenamientoAsc = true)
    {
        var response = await _mediator.Send(new ConsultarIlicitosRespuestaPorIdQuery(respuestaLaftId, pagina, registrosPorPagina, ordenarPor, ordenamientoAsc));

        return Ok(response);
    }
}