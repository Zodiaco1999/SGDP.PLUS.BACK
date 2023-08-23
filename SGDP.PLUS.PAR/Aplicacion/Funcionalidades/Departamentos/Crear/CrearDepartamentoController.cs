using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearDepartamentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearDepartamentoController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearDepartamento(CrearDepartamentoCommand command)
    {
        CrearDepartamentoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}