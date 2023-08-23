using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarTipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarTipoDocumentoController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{tipoDocumentoId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarTipoDocumento(int tipoDocumentoId)
    {
        ActivarInactivarTipoDocumentoResponse response = await _mediator.Send(new ActivarInactivarTipoDocumentoCommand(tipoDocumentoId));

        return Ok(response);
    }
}