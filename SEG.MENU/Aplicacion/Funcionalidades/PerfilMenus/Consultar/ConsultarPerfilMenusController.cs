using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfilMenus(Guid perfilId, Guid? aplicacionId, Guid? moduloId, int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarPerfilMenusResponse> resultado = await _mediator.Send(new ConsultarPerfilMenusQuery(perfilId, aplicacionId, moduloId, textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }


}
