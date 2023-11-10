using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultaLaftController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ConsultaLaft()
        {
            return Ok("Autorizado");
        }
    }
}
