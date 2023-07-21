using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfiles(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarPerfilesResponse> resultado = await _mediator.Send(new ConsultarPerfilesQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }


}
