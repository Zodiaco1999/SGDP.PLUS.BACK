using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;

public record struct EditarDepartamentoCommand(
    Guid DepartamentoId,
    Guid PaisId,
    string Nombre,
    string Codigo
    ) : IRequest<EditarDepartamentoResponse>;