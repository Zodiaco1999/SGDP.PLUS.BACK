using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.BuscadorTercero;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class BuscadorTerceroController : ControllerBase
{
    private readonly IMediator _mediator;
    public BuscadorTerceroController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> BuscadorTercero(BuscadorTerceroCommand command)
        => Ok(await _mediator.Send(command));
}
