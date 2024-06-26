using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

public class GestionUsuariosSesionLog : BaseAppService, IGestionUsuariosSesionLog
{
    private readonly IUsuarioSesionLogRepositorioLectura _usuariosesionlogLectura;
    private readonly IUsuarioSesionLogRepositorioEscritura _usuariosesionlogEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionUsuariosSesionLog(
        IUsuarioSesionLogRepositorioLectura usuariosesionlogLectura,
        IUsuarioSesionLogRepositorioEscritura usuariosesionlogEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuariosesionlogLectura = usuariosesionlogLectura;
        _usuariosesionlogEscritura = usuariosesionlogEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<DataViewModel<ConsultarUsuariosSesionLogResponse>> ConsultarUsuariosSesionLog(GetEntityQuery query)
    {
        try
        {
            var filtroEspecificacion = new UsuarioSesionLogEspecificacion(query.TextoBusqueda);

            var result = await _usuariosesionlogLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(query.OrdenarPor, query.OrdenamientoAsc)
                .SelectPageAsync(query.Pagina, query.RegistrosPorPagina);

            DataViewModel<ConsultarUsuariosSesionLogResponse> consulta = new(query.Pagina, query.RegistrosPorPagina, result.TotalItems);

            consulta.Data = result.Items.Select(item => new ConsultarUsuariosSesionLogResponse(
                                item.LogId,
                                item.UsuarioId,
                                item.SesionId,
                                item.Fecha,
                                item.IpCliente,
                                item.DataSesion,
                                item.Accion,
                                item.MsgValidacion)).ToList();

            return consulta;
        }
        catch (Exception ex)
        {
            throw new BadRequestCustomException("Error consultando UsuarioSesionLog", ex);
        }
    }

    public async Task<ConsultarUsuarioSesionLogPorIdResponse> ConsultarUsuarioSesionLogPorId(Guid logId)
    {
        var result = await _usuariosesionlogLectura
              .Query(p => p.LogId == logId)
              .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesionLog), logId);

        return new ConsultarUsuarioSesionLogPorIdResponse(
            result.LogId,
            result.UsuarioId,
            result.SesionId,
            result.Fecha,
            result.IpCliente,
            result.DataSesion,
            result.Accion,
            result.MsgValidacion);

    }

    public async Task<CrearUsuarioSesionLogResponse> CrearUsuarioSesionLog(CrearUsuarioSesionLogCommand registroDto)
    {
        var registro = new UsuarioSesionLog()
        {
            LogId = registroDto.LogId,
            UsuarioId = registroDto.UsuarioId,
            SesionId = registroDto.SesionId,
            Fecha = registroDto.Fecha,
            IpCliente = registroDto.IpCliente,
            DataSesion = registroDto.DataSesion,
            Accion = registroDto.Accion,
            MsgValidacion = registroDto.MsgValidacion,
        };

        _usuariosesionlogEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearUsuarioSesionLogResponse(
            registro.LogId,
            registro.UsuarioId,
            registro.SesionId,
            registro.Fecha,
            registro.IpCliente,
            registro.DataSesion,
            registro.Accion,
            registro.MsgValidacion);
    }

    public async Task<EditarUsuarioSesionLogResponse> EditarUsuarioSesionLog(EditarUsuarioSesionLogCommand registroDto)
    {
        var regActualizar = await _usuariosesionlogEscritura
            .Query(x => x.LogId == registroDto.LogId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesionLog), registroDto.LogId);
        

        regActualizar.LogId = registroDto.LogId;
        regActualizar.UsuarioId = registroDto.UsuarioId;
        regActualizar.SesionId = registroDto.SesionId;
        regActualizar.Fecha = registroDto.Fecha;
        regActualizar.IpCliente = registroDto.IpCliente;
        regActualizar.DataSesion = registroDto.DataSesion;
        regActualizar.Accion = registroDto.Accion;
        regActualizar.MsgValidacion = registroDto.MsgValidacion;

        _usuariosesionlogEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _usuariosesionlogEscritura
            .Query(x => x.LogId == registroDto.LogId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(UsuarioSesionLog), registroDto.LogId);

        return new EditarUsuarioSesionLogResponse(
            regActualizado.LogId,
            regActualizado.UsuarioId,
            regActualizado.SesionId,
            regActualizado.Fecha,
            regActualizado.IpCliente,
            regActualizado.DataSesion,
            regActualizado.Accion,
            regActualizado.MsgValidacion);
    }
}