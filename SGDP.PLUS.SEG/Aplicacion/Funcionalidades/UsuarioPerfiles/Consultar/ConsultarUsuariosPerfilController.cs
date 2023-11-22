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

        public async Task<IActionResult> ConsultarUsuariosPerfil(string usuarioId, Guid perfilId, Guid? aplicacionId, int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
        {
             DataViewModel<ConsultarUsuariosPerfilResponse> resultado = await _mediator.Send(new ConsultarUsuariosPerfilQuery(usuarioId, perfilId, aplicacionId, textoBusqueda, pagina, registrosPorPagina));

             return Ok(resultado);
        }
    }

