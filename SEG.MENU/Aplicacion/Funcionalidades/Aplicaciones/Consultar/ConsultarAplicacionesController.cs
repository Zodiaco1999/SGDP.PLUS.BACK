using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

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



    [HttpGet("{texto}/{pagina}/{regXpagina}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ConsultarAplicaciones(string texto, int pagina, int regXpagina)
    {
        var response = await _mediator.Send(new ConsultarAplicacionesQuery(texto, pagina, regXpagina));

        return Ok(response);
    }
}
