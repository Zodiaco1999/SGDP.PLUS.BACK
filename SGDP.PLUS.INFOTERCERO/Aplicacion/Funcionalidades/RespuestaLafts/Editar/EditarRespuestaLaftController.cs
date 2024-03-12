using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarRespuestaLaftController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarRespuestaLaftController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarRespuestaLaft()
    {
        EditarRespuestaLaftResponse response = await _mediator.Send(new EditarRespuestaLaftCommand());

        return Ok(response);
    }
}