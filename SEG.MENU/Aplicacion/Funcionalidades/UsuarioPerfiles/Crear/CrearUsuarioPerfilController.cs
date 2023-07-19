using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearUsuarioPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CrearUsuarioPerfilController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CrearUsuarioPerfil(CrearUsuarioPerfilCommand command)
        {
            CrearUsuarioPerfilResponse response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
