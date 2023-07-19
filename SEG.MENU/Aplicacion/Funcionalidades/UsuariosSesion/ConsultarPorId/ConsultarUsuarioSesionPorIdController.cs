using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarUsuarioSesionPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuarioSesionPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarioSesionPorId(string usuarioId)
    {
        var response = await _mediator.Send(new ConsultarUsuarioSesionPorIdQuery(usuarioId));

        return Ok(response);
    }
}