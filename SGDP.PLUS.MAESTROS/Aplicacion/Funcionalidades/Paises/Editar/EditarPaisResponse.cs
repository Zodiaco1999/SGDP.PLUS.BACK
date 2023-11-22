namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;

public record struct EditarPaisResponse(
    Guid PaisoId,
    string Nombre,
    string Codigo,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );