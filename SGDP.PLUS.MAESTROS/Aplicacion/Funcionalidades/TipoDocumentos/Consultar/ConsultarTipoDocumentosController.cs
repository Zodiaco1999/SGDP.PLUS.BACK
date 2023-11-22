using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarTipoDocumentosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarTipoDocumentosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarTipoDocumentos(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel <ConsultarTipoDocumentosResponse> response = await _mediator.Send(new ConsultarTipoDocumentosQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}