using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.EnviarCorreoContrasena
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviarCorreoContrasenaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnviarCorreoContrasenaController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EnviarCorreoContrasena(EnviarCorreoContrasenaCommand command)
        {
            EnviarCorreoContrasenaResponse response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
