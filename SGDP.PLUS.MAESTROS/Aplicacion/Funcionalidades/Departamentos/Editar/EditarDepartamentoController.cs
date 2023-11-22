using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarDepartamentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarDepartamentoController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarDepartamento(EditarDepartamentoCommand command)
    {
        EditarDepartamentoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}