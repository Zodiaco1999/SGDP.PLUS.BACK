using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Consultar;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarIlicitosRespuestasController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarIlicitosRespuestasController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarIlicitosRespuestas(string nit, DateTime fechaSolicitud, int pagina = 1, int registrosPorPagina = 10, string ordenarPor = "ConsultaRealizada", bool ordenamientoAsc = true)
    {
        var response = await _mediator.Send(new ConsultarIlicitosRespuestasQuery(nit, fechaSolicitud, pagina, registrosPorPagina, ordenarPor, ordenamientoAsc));

        return Ok(response);
    }
}