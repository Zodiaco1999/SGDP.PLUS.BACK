using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

    public interface IGestionUsuarioPerfil
    {
        Task<DataViewModel<ConsultarUsuariosPerfilResponse>> ConsultarUsuariosPerfil(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
        Task<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>> ConsultarUsuarioPerfilPorId(string usuarioId);
        Task<CrearUsuarioPerfilResponse> CrearUsuarioPerfil(CrearUsuarioPerfilCommand registroDto);
        Task EditarUsuarioPerfil(List<EditarUsuarioPerfilCommand> usuarioPerfilDto, string usuarioId);
    }

