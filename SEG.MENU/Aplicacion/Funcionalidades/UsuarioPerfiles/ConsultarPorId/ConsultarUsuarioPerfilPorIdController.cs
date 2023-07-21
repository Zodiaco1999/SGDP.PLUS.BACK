using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

[Route("api/[controller]")]    
[ApiController]
public class ConsultarUsuarioPerfilPorIdController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConsultarUsuarioPerfilPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{usuarioId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ConsultarUsuarioPerfilPorId(string usuarioId)
    {
        var response = await _mediator.Send(new ConsultarUsuarioPerfilPorIdQuery(usuarioId));

        return Ok(response);
    }

}
   
