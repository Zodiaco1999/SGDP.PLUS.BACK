using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarDepartamentoPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarDepartamentoPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarDepartamentoPorId(Guid DepartamentoID)
    {
        ConsultarDepartamentoPorIdResponse response = await _mediator.Send(new ConsultarDepartamentoPorIdQuery(DepartamentoID));

        return Ok(response);
    }
}