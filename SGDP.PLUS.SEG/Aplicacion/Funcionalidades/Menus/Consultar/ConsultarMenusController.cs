using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenusController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenusController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenus([FromQuery] GetEntityQuery query, Guid aplicacionId, Guid? moduloId)
    {
        DataViewModel<ConsultarMenusResponse> response = await _mediator.Send(new ConsultarMenusQuery(query, aplicacionId, moduloId));

        return Ok(response);
    }
}