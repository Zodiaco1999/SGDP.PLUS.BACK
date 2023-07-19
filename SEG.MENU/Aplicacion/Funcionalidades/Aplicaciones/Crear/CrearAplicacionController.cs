using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

[ApiController]
[Route("api/[controller]")]

public class CrearAplicacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearAplicacionController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearAplicacion(CrearAplicacionCommand command)
    {
        CrearAplicacionResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
