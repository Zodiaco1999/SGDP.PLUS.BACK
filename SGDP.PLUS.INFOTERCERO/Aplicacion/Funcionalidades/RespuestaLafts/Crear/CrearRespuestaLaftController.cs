using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearRespuestaLaftController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearRespuestaLaftController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearRespuestaLaft()
    {
        CrearRespuestaLaftResponse response = await _mediator.Send(new CrearRespuestaLaftCommand());

        return Ok(response);
    }
}