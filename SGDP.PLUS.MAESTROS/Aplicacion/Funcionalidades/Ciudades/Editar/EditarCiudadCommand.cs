using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;

public record struct EditarCiudadCommand(
    Guid CiudadId,
    Guid? DepartamentoId,
    string Nombre,
    string Codigo
    ) : IRequest<EditarCiudadResponse>;