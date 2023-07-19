using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearModuloController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearModuloController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearModulo(CrearModuloCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}