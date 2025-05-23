﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ObtenerInformeController : ControllerBase
{
    private readonly IMediator _mediator;
    public ObtenerInformeController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObtenerInforme(ObtenerInformeCommand command)
        => Ok(await _mediator.Send(command));
}
