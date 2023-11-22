using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarCiudadesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarCiudadesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarCiudades(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarCiudadesResponse> response = await _mediator.Send(new ConsultarCiudadesQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}