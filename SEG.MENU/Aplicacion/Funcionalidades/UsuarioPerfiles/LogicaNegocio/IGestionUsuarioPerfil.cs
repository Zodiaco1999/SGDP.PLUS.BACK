using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

    public interface IGestionUsuarioPerfil
    {
        Task<DataViewModel<ConsultarUsuariosPerfilResponse>> ConsultarUsuariosPerfil(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
        Task<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>> ConsultarUsuarioPerfilPorId(string usuarioId);
        Task<CrearUsuarioPerfilResponse> CrearUsuarioPerfil(CrearUsuarioPerfilCommand registroDto);
        Task<EditarUsuarioPerfilResponse> EditarUsuarioPerfil(EditarUsuarioPerfilCommand registroDto);
    }

