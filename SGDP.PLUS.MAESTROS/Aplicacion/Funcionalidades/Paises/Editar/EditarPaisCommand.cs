using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;

public record struct EditarPaisCommand(Guid PaisId, string Nombre, string Codigo) : IRequest<EditarPaisResponse>;