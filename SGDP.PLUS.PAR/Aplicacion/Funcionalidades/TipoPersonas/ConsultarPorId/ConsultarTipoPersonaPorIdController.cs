using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarTipoPersonaPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarTipoPersonaPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarTipoPersonaPorId(Guid tipopersonaID)
    {
        ConsultarTipoPersonaPorIdResponse response = await _mediator.Send(new ConsultarTipoPersonaPorIdQuery(tipopersonaID));

        return Ok(response);
    }
}