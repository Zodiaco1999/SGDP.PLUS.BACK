using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarUsuarioController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarUsuario(string usuarioId)
    {
        ActivarInactivarUsuarioResponse response = await _mediator.Send(new ActivarInactivarUsuarioCommand(usuarioId));

        return Ok(response);
    }
}