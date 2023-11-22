using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Consultar;

[Route("api/[controller]")]
[ApiController]
public class ConsultarDepartamentosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarDepartamentosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarDepartamentos(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
    {
        DataViewModel<ConsultarDepartamentosResponse> response = await _mediator.Send(new ConsultarDepartamentosQuery(textoBusqueda, pagina, registrosPorPagina));

        return Ok(response);
    }
}