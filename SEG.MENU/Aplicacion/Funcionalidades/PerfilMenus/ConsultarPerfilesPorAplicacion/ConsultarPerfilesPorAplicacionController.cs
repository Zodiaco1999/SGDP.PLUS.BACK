using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultarPerfilesPorAplicacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsultarPerfilesPorAplicacionController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{aplicacionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarPerfilesPorAplicacion(Guid aplicacionId)
        {
            var response = await _mediator.Send(new ConsultarPerfilesPorAplicacionQuery(aplicacionId));

            return Ok(response);
        }
    }
}
