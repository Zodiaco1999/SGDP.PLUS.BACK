using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarAplicacionesController(IMediator mediator) => _mediator = mediator;


    //[HttpGet("{texto}/{pagina}/{regXpagina}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> ConsultarAplicaciones(string texto, int pagina, int regXpagina)
    //{
    //    var response = await _mediator.Send(new ConsultarAplicacionesQuery(texto, pagina, regXpagina));

    //    return Ok(response);
    //}

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(short? empresaId, int pagina = 1, int registrosPorPagina =20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarAplicacionesResponse> resultado = await _mediator.Send(new ConsultarAplicacionesQuery(textoBusqueda, pagina, registrosPorPagina));

        DataViewModel<ConsultarAplicacionesResponse> data = new DataViewModel<ConsultarAplicacionesResponse>(pagina, registrosPorPagina, resultado.TotalRecords)
        {
            Data = resultado.Data
        };

        return Ok(data);
    }
}
