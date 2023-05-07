using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearAplicacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> CrearAplicaciones(CrearAplicacionesCommand command)
    {
        CrearAplicacionesResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
