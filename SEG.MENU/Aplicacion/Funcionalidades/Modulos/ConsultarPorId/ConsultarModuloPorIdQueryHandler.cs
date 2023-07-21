using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

public class ConsultarModuloPorIdQueryHandler : IRequestHandler<ConsultarModuloPorIdQuery, ConsultarModuloPorIdResponse>
{
    private readonly IGestionModulos _gestionModulos;
    public ConsultarModuloPorIdQueryHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task<ConsultarModuloPorIdResponse> Handle(ConsultarModuloPorIdQuery request, CancellationToken cancellationToken)
        => await _gestionModulos.ConsultarModuloPorId(request.moduloId);
}