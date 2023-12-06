using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ConsultaLaftController : ControllerBase
{

    private readonly IMediator _mediator;
    public ConsultaLaftController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> ConsultaLaft(ConsultaLaftCommand command)
        => Ok(await _mediator.Send(command));
}
