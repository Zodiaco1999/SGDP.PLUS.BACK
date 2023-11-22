using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarModulosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarModulosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarModulos(Guid aplicacionId, bool? activo = null)
    {
        IEnumerable<ConsultarModulosResponse> response = await _mediator.Send(new ConsultarModulosQuery(aplicacionId, activo));

        return Ok(response);
    }
}