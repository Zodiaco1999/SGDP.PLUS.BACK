using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

public class GestionUsuariosSesion : BaseAppService, IGestionUsuariosSesion
{
    private readonly IUsuarioSesionRepositorioLectura _usuariosesionLectura;
    private readonly IUsuarioSesionRepositorioEscritura _usuariosesionEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuariosSesion(
        IUsuarioSesionRepositorioLectura usuariosesionLectura,
        IUsuarioSesionRepositorioEscritura usuariosesionEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuariosesionLectura = usuariosesionLectura;
        _usuariosesionEscritura = usuariosesionEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarUsuariosSesionResponse>> ConsultarUsuariosSesion(GetEntityQuery query)
    {
        try
        {
            var filtroEspecificacion = new UsuarioSesionEspecificacion(query.TextoBusqueda);

            var result = await _usuariosesionLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
                .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

            DataViewModel<ConsultarUsuariosSesionResponse> consulta = new(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

            consulta.Data = result.Items.Select(item => new ConsultarUsuariosSesionResponse(
                item.UsuarioId,
                item.SesionId,
                item.InicioSesion,
                item.IpCliente,
                item.TokenActualizacion,
                item.CreaUsuario,
                item.CreaFecha,
                item.ModificaUsuario,
                item.ModificaFecha)).ToList();

            return consulta;
        }
        catch (Exception ex)
        {
            throw new BadRequestCustomException("Error consultando UsuarioSesion", ex);
        }
    }

    public async Task<ConsultarUsuarioSesionPorIdResponse> ConsultarUsuarioSesionPorId(string usuarioId)
    {
        var result = await _usuariosesionLectura
               .Query(p => p.UsuarioId == usuarioId)
               .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesion), usuarioId);

        return new ConsultarUsuarioSesionPorIdResponse(
            result.UsuarioId,
            result.SesionId,
            result.InicioSesion,
            result.IpCliente,
            result.TokenActualizacion,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha);
    }
    public async Task<CrearUsuarioSesionResponse> CrearUsuarioSesion(CrearUsuarioSesionCommand registroDto)
    {
        var registro = new UsuarioSesion()
        {
            UsuarioId = registroDto.UsuarioId,
            SesionId = registroDto.SesionId,
            InicioSesion = registroDto.InicioSesion,
            IpCliente = registroDto.IpCliente,
            TokenActualizacion = registroDto.TokenActualizacion,
        };

        _usuariosesionEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearUsuarioSesionResponse(
            registro.UsuarioId,
            registro.SesionId,
            registro.InicioSesion,
            registro.IpCliente,
            registro.TokenActualizacion);
    }

    public async Task<EditarUsuarioSesionResponse> EditarUsuarioSesion(EditarUsuarioSesionCommand registroDto)
    {
        var regActualizar = await _usuariosesionEscritura
            .Query(x => x.UsuarioId == registroDto.UsuarioId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesion), registroDto.UsuarioId);

        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.SesionId = registroDto.SesionId;
        regActualizar.InicioSesion = registroDto.InicioSesion;
        regActualizar.IpCliente = registroDto.IpCliente;
        regActualizar.TokenActualizacion = registroDto.TokenActualizacion;

        _usuariosesionEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuariosesionEscritura
            .Query(x => x.UsuarioId == registroDto.UsuarioId && x.SesionId == registroDto.SesionId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesion), registroDto.UsuarioId);

        return new EditarUsuarioSesionResponse(
            regActualizado.UsuarioId,
            regActualizado.SesionId,
            regActualizado.InicioSesion,
            regActualizado.IpCliente,
            regActualizado.TokenActualizacion,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}