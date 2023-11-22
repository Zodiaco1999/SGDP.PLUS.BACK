using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenusPorParametrosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenusPorParametrosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenusPorParametros(Guid aplicacionId, Guid? moduloId = null, string textoBusqueda = "")
    {
        var response = await _mediator.Send(new ConsultarMenusPorParametrosQuery(aplicacionId, moduloId, textoBusqueda));

        return Ok(response);
    }
}