using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuarioPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuarioPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarioPorId(string usuarioId)
    {
        var  response = await _mediator.Send(new ConsultarUsuarioPorIdQuery(usuarioId));
        return Ok(response);
    }
}