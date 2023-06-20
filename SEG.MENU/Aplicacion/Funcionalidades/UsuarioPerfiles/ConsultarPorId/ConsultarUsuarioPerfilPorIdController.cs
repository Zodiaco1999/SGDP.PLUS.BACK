using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

[Route("api/[controller]")]    
[ApiController]
public class ConsultarUsuarioPerfilPorIdController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConsultarUsuarioPerfilPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ConsultarUsuarioPerfilPorId(Guid perfilId, string usuarioId)
    {
        var response = await _mediator.Send(new ConsultarUsuarioPerfilPorIdQuery(perfilId, usuarioId));

        return Ok(response);
    }

}
   
