using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContrasena;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContraseña
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CambiarContrasenaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CambiarContrasenaController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CambiarContrasena(CambiarContrasenaCommand command)
        {
           CambiarContrasenaResponse response = await _mediator.Send(command);

           return Ok(response);
        }
    }
}
