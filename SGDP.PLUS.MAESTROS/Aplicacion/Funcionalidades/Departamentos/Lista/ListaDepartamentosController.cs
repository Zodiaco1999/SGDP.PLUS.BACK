using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Lista;

    [Route("api/[controller]")]
    [ApiController]
    public class ListaDepartamentosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ListaDepartamentosController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarDepartamentos()
        {
            var response = await _mediator.Send(new ListaDepartamentosQuery());

            return Ok(response);
        }
    }

