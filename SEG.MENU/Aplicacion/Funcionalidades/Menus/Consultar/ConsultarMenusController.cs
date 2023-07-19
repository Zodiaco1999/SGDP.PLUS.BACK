using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenus(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarMenusResponse> response = await _mediator.Send(new ConsultarMenusQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}