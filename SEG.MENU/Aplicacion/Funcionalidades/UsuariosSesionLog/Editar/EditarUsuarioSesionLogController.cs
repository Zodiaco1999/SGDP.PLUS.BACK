using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarUsuarioSesionLogController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarUsuarioSesionLogController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarUsuarioSesionLog(EditarUsuarioSesionLogCommand command)
    {
        EditarUsuarioSesionLogResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}