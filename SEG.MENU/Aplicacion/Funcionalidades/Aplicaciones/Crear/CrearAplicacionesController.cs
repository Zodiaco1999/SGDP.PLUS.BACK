using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

[ApiController]
[Route("api/[controller]")]

public class CrearAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrearAplicacionesController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CrearAplicaciones(CrearAplicacionesCommand command)
    {
        CrearAplicacionesResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
