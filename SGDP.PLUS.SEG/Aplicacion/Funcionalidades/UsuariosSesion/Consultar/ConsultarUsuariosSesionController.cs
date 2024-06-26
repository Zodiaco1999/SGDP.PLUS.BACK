using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

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
    public async Task<IActionResult> ConsultarUsuariosSesion([FromQuery] GetEntityQuery query)
    {
        DataViewModel<ConsultarUsuariosSesionResponse> resultado = await _mediator.Send(new ConsultarUsuariosSesionQuery(query));

        return Ok(resultado);
    }
}