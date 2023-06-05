using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfilPorId(Guid perfilId)
    {
        var response = await _mediator.Send(new ConsultarPerfilPorIdQuery(perfilId));

        return Ok(response);
    }
}
