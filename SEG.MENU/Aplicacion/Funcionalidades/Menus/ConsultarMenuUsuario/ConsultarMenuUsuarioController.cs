using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;

[Route("api/[controller]")]
[ApiController]
public class ConsultarMenuUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarMenuUsuarioController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarMenuUsuario()
    {
        var response = await _mediator.Send(new ConsultarMenuUsuarioQuery());

        return Ok(response);
    }

}
