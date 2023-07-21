using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;

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