using MediatR;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarModuloPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarModuloPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{moduloId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarModuloPorId(Guid moduloId)
    {
        ConsultarModuloPorIdResponse response = await _mediator.Send(new ConsultarModuloPorIdQuery(moduloId));

        return Ok(response);
    }
}