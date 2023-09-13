using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.ReestablecerContrasena
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReestablecerContrasenaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReestablecerContrasenaController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReestablecerContrasena(ReestablecerContrasenaCommand command)
        {
            ReestablecerContrasenaResponse response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
