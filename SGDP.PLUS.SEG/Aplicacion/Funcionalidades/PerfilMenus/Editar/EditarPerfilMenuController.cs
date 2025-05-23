﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarPerfilMenuController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditarPerfilMenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarPerfilMenu(EditarPerfilMenuCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
