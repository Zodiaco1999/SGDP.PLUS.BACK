using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Consultar;

public record struct ConsultarIlicitosRespuestasQuery(string Nit, DateTime FechaSolicitud, int Pagina, int RegistrosPorPagina, string OrdenarPor, bool OrdenamientoAsc) : IRequest<DataViewModel<ConsultarIlicitosRespuestasResponse>>;