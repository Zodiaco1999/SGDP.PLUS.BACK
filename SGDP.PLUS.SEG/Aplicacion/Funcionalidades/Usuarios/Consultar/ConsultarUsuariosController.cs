using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ConsultarUsuariosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuariosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarios(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarUsuariosResponse> resultado = await _mediator.Send(new ConsultarUsuariosQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(resultado);
    }
}