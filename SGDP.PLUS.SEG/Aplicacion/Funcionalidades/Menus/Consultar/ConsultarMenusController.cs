using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{aplicacionId}/{moduloId?}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenus(Guid aplicacionId, Guid? moduloId = null, int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarMenusResponse> response = await _mediator.Send(new ConsultarMenusQuery(aplicacionId, moduloId, textoBusqueda, pagina, registrosPorPagina, ordenarPor, direccionOrdenamientoAsc));

        return Ok(response);
    }
}