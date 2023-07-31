using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarDepartamentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarDepartamentoController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarDepartamento(Guid DepartamentoId)
    {
        ActivarInactivarDepartamentoResponse response = await _mediator.Send(new ActivarInactivarDepartamentoCommand(DepartamentoId));

        return Ok(response);
    }
}