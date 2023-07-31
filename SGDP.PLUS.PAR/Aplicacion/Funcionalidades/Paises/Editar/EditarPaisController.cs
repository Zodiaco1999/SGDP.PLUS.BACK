using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarPaisController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarPaisController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarPais(EditarPaisCommand command)
    {
        EditarPaisResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}