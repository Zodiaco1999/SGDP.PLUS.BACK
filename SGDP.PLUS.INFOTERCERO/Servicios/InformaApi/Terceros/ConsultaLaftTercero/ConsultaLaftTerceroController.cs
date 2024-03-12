using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaftTercero;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsultaLaftTerceroController : ControllerBase
{

    private readonly IMediator _mediator;
    public ConsultaLaftTerceroController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> ConsultaLaft(ConsultaLaftTerceroCommand command)
        => Ok(await _mediator.Send(command));
}
