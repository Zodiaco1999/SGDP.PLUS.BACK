using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarTipoDocumentoPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarTipoDocumentoPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarTipoDocumentoPorId(int tipodocumentoId)
    {
        ConsultarTipoDocumentoPorIdResponse response = await _mediator.Send(new ConsultarTipoDocumentoPorIdQuery(tipodocumentoId));

        return Ok(response);
    }
}