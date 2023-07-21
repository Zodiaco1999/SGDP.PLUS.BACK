using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuariosSesionLogController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuariosSesionLogController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuariosSesionLog(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarUsuariosSesionLogResponse> resultado = await _mediator.Send(new ConsultarUsuariosSesionLogQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }
}