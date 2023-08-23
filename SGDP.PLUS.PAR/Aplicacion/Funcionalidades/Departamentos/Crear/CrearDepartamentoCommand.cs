using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;

public record struct CrearDepartamentoCommand(
    Guid? PaisId,
    string Nombre,
    string Codigo
    ) : IRequest<CrearDepartamentoResponse>;