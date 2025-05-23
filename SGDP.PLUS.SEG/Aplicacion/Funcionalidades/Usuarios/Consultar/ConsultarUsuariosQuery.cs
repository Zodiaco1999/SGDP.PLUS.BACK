using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;

public record struct ConsultarUsuariosQuery(GetEntityQuery query) : IRequest<DataViewModel<ConsultarUsuariosResponse>>;