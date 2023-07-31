using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarTipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarTipoDocumentoController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarTipoDocumento(int TipoDocumentoId)
    {
        ActivarInactivarTipoDocumentoResponse response = await _mediator.Send(new ActivarInactivarTipoDocumentoCommand(TipoDocumentoId));

        return Ok(response);
    }
}