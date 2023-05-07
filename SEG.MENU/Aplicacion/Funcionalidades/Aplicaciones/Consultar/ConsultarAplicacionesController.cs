using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarAplicacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarAplicaciones() =>
        Ok(await _mediator.Send(new ConsultarAplicacionesQuery()));
}
