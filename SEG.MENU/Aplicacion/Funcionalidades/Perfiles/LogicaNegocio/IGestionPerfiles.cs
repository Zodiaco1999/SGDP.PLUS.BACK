using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio
{
    public interface IGestionPerfiles
    {
        Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
        Task<ConsultarPerfilPorIdResponse> ConsultarPerfil(Guid perfilId);
        Task<CrearPerfilesResponse> CrearPerfil(CrearPerfilesCommand registroDto);
        Task<EditarPerfilesResponse> ActualizarPerfil(EditarPerfilesCommand registroDto);
        Task<ActivarInactivarPerfilesResponse> ActivarInactivar(Guid perfilId);
    }
}