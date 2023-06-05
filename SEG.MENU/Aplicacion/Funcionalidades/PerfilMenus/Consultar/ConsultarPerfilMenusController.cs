using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarPerfilMenusResponse> resultado = await _mediator.Send(new ConsultarPerfilMenusQuery(textoBusqueda, pagina, registrosPorPagina));

        DataViewModel<ConsultarPerfilMenusResponse> data = new DataViewModel<ConsultarPerfilMenusResponse>(pagina, registrosPorPagina, resultado.TotalRecords)
        {
            Data = resultado.Data
        };

        return Ok(data);
    }


}
