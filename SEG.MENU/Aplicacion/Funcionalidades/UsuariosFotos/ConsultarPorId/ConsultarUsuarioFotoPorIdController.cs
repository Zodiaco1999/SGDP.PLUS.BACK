using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultarUsuarioFotoPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarUsuarioFotoPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarUsuarioFotoPorId()
    {
        var response = await _mediator.Send(new ConsultarUsuarioFotoPorIdQuery());

        return Ok(response);
    }
}