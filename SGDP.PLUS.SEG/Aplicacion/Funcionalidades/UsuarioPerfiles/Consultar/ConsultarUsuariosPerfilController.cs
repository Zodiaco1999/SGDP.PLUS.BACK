using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

[Route("api/[controller]")]
    [ApiController]
    public class ConsultarUsuariosPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultarUsuariosPerfilController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ConsultarUsuariosPerfil([FromQuery] GetEntityQuery query, Guid? aplicacionId)
        {
             DataViewModel<ConsultarUsuariosPerfilResponse> resultado = await _mediator.Send(new ConsultarUsuariosPerfilQuery(query, aplicacionId));

             return Ok(resultado);
        }
    }

