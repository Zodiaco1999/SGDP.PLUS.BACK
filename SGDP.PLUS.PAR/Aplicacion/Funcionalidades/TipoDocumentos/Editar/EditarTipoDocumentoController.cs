using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarTipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarTipoDocumentoController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarTipoDocumento(EditarTipoDocumentoCommand command)
    {
        EditarTipoDocumentoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}