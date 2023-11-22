using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Lista;

[Route("api/[controller]")]
[ApiController]
public class ListaTipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ListaTipoDocumentoController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ListaTipoDocumento()
    {
        var response = await _mediator.Send(new ListaTipoDocumentoQuery());

        return Ok(response);
    }
}

