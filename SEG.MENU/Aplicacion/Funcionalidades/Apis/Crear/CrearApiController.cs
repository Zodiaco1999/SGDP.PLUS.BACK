using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearApiController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearApiController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearApi(CrearApiCommand command)
    {
        CrearApiResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}