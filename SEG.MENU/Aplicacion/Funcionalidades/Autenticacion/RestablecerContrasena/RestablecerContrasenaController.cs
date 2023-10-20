using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.RestablecerContrasena
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestablecerContrasenaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestablecerContrasenaController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReestablecerContrasena(RestablecerContrasenaCommand command)
        {
            RestablecerContrasenaResponse response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
