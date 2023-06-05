using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarPerfilesResponse> resultado = await _mediator.Send(new ConsultarPerfilesQuery(textoBusqueda, pagina, registrosPorPagina));

        DataViewModel<ConsultarPerfilesResponse> data = new DataViewModel<ConsultarPerfilesResponse>(pagina, registrosPorPagina, resultado.TotalRecords)
        {
            Data = resultado.Data
        };

        return Ok(data);
    }


}
