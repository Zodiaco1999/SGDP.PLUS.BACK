using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuariosSesionController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuariosSesionController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuariosSesion(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarUsuariosSesionResponse> resultado = await _mediator.Send(new ConsultarUsuariosSesionQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }
}