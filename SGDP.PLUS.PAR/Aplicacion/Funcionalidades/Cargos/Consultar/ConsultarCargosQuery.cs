using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;

public record struct ConsultarCargosQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarCargosResponse>>;