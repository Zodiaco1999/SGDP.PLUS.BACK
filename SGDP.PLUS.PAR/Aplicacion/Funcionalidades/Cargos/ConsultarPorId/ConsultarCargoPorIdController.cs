using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarCargoPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarCargoPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{cargoId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarCargoPorId(Guid CargoId)
    {
        ConsultarCargoPorIdResponse response = await _mediator.Send(new ConsultarCargoPorIdQuery(CargoId));

        return Ok(response);
    }
}