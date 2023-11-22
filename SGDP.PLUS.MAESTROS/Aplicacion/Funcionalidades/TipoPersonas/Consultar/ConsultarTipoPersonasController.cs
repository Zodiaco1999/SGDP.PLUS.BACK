using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarTipoPersonasController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarTipoPersonasController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarTipoPersonas(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarTipoPersonasResponse> resultado = await _mediator.Send(new ConsultarTipoPersonasQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }
}