using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;

[Route("api/[controller]")]
[ApiController]
public class RefreshController : ControllerBase
{
    private readonly IMediator _mediator;
    public RefreshController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{tokenRefresh}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Refresh(string tokenRefresh)
    {
        string? jwt = Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(jwt)) 
        {
            throw new ValidationException("Su sesión caduco, Inicie Sesión nuevamente");
        }   

        var response = await _mediator.Send(new RefreshCommand(tokenRefresh, jwt));

        return Ok(response);
    }
}
