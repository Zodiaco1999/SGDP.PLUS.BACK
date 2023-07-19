using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarModuloController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarModuloController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarModulo(EditarModuloCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}