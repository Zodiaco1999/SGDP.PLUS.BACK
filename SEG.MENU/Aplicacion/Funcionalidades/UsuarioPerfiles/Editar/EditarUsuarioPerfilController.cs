using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

    [Route("api/[controller]")]
    [ApiController]
    public class EditarUsuarioPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EditarUsuarioPerfilController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> EditarUsuarioPerfil(EditarUsuarioPerfilCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
}

