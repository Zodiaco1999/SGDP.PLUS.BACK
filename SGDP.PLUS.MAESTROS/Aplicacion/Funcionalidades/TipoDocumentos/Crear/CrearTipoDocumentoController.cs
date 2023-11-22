using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearTipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearTipoDocumentoController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearTipoDocumento(CrearTipoDocumentoCommand command)
    {
        CrearTipoDocumentoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}