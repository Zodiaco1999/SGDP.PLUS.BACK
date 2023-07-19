using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarApiController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarApiController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarApi(EditarApiCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}