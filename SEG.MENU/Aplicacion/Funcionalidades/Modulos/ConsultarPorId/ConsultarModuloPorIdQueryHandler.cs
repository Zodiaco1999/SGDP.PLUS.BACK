using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

public class ConsultarModuloPorIdQueryHandler : IRequestHandler<ConsultarModuloPorIdQuery, ConsultarModuloPorIdResponse>
{
    private readonly IGestionModulos _gestionModulos;
    public ConsultarModuloPorIdQueryHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task<ConsultarModuloPorIdResponse> Handle(ConsultarModuloPorIdQuery request, CancellationToken cancellationToken)
        => await _gestionModulos.ConsultarModuloPorId(request.moduloId);
}