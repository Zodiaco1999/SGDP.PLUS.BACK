using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarCargosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarCargosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarCargos(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarCargosResponse> response = await _mediator.Send(new ConsultarCargosQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}