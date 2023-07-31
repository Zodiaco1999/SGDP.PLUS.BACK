using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPaisPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPaisPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPaisPorId(Guid paisId)
    {
        ConsultarPaisPorIdResponse response = await _mediator.Send(new ConsultarPaisPorIdQuery(paisId));

        return Ok(response);
    }
}