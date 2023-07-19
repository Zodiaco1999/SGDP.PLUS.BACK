using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPerfilMenuPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPerfilMenuPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPerfilMenuPorId(Guid perfilId)
    {
        var response = await _mediator.Send(new ConsultarPerfilMenuPorIdQuery(perfilId));

        return Ok(response);
    }
}
