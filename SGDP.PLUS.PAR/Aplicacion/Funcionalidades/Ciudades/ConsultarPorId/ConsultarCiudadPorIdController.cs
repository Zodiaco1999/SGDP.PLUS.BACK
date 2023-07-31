using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;

[Route("api/[controller]")]
[ApiController]
public class ConsultarCiudadPorIdController : ControllerBase
{
    private readonly IMediator _mediator;
    public ConsultarCiudadPorIdController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarCiudadPorId(Guid CiudadId)
    {
        ConsultarCiudadPorIdResponse response = await _mediator.Send(new ConsultarCiudadPorIdQuery(CiudadId));

        return Ok(response);
    }
}