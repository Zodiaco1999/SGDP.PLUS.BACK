using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuarioFotoPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuarioFotoPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{usuarioId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarioFotoPorId(string usuarioId)
    {
        var response = await _mediator.Send(new ConsultarUsuarioFotoPorIdQuery(usuarioId));

        return Ok(response);
    }
}