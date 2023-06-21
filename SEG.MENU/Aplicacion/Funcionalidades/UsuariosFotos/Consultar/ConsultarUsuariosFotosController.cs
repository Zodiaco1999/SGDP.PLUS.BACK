using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuariosFotosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuariosFotosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarUsuariosFotosResponse> resultado = await _mediator.Send(new ConsultarUsuariosFotosQuery(textoBusqueda, pagina, registrosPorPagina));

        DataViewModel<ConsultarUsuariosFotosResponse> data = new DataViewModel<ConsultarUsuariosFotosResponse>(pagina, registrosPorPagina, resultado.TotalRecords)
        {
            Data = resultado.Data
        };
        return Ok(data);
    }
}