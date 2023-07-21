using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenuPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenuPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{menuId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenuPorId(Guid menuId)
    {
        ConsultarMenuPorIdResponse response = await _mediator.Send(new ConsultarMenuPorIdQuery(menuId));

        return Ok(response);
    }
}