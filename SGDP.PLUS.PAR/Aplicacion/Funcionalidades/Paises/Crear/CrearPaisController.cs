using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearPaisController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearPaisController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearPais(CrearPaisCommand command)
    {
        CrearPaisResponse response = await _mediator.Send(command);
        
        return Ok(response);
    }
}