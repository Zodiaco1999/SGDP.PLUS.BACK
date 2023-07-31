using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;
using System.Data;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarPaisesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarPaisesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPaises(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarPaisesResponse> response = await _mediator.Send(new ConsultarPaisesQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}