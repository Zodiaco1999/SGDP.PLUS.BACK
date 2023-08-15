using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Lista;

[Route("api/[controller]")]
[ApiController]
public class ListaAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ListaAplicacionesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        IEnumerable<ListaAplicacionesResponse> resultado = await _mediator.Send(new ListaAplicacionesQuery());

        return Ok(resultado);
    }
}
