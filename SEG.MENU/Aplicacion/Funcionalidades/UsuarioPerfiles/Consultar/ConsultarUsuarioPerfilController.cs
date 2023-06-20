using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    [Route("api/[controller]")]
    [ApiController]
    public class ConsultarUsuarioPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultarUsuarioPerfilController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get(int pagina = 1, int registrosPorPagina = 20, string textoBusqueda = "", string ordenarPor = "", bool direccionOrdenamientoAsc = true)
        {
             DataViewModel<ConsultarUsuarioPerfilResponse> resultado = await _mediator.Send(new ConsultarUsuarioPerfilQuery(textoBusqueda, pagina, registrosPorPagina));

            DataViewModel<ConsultarUsuarioPerfilResponse> data = new DataViewModel<ConsultarUsuarioPerfilResponse>(pagina, registrosPorPagina, resultado.TotalRecords)
            {
                Data = resultado.Data
            };
            return Ok(data);
        }
    }

