using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuariosFotosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuariosFotosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuariosFotos(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarUsuariosFotosResponse> resultado = await _mediator.Send(new ConsultarUsuariosFotosQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }
}