using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarApiController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarApiController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{apiId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarApi(Guid apiId)
    {
        await _mediator.Send(new ActivarInactivarApiCommand(apiId));

        return Ok();
    }
}