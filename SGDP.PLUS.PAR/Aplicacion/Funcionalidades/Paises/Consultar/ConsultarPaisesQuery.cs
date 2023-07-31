using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;

public record struct ConsultarPaisesQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarPaisesResponse>>;