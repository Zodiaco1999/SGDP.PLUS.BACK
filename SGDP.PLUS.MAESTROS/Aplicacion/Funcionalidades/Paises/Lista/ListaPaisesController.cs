using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;

[Route("api/[controller]")]
[ApiController]
public class ListaPaisesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ListaPaisesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPaises()
    {
        var response = await _mediator.Send(new ListaPaisesQuery());

        return Ok(response);
    }
}