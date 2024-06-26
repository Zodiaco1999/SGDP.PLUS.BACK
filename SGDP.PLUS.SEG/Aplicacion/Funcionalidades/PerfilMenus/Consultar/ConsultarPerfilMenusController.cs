using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfilMenus([FromQuery] GetEntityQuery query, Guid perfilId, Guid? moduloId)
    {
        DataViewModel<ConsultarPerfilMenusResponse> resultado = await _mediator.Send(new ConsultarPerfilMenusQuery(query ,perfilId, moduloId));

        return Ok(resultado);
    }
}
