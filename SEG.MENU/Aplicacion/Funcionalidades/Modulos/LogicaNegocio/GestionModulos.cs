using Ardalis.GuardClauses;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Especificacion;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

public class GestionModulos : BaseAppService, IGestionModulos
{
    private readonly IModuloRepositorioLectura _moduloRepositorioLectura;
    private readonly IModuloRepositorioEscritura _moduloRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionModulos(
        IModuloRepositorioLectura moduloRepositorioLectura,
        IModuloRepositorioEscritura moduloRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _moduloRepositorioLectura = moduloRepositorioLectura;
        _moduloRepositorioEscritura = moduloRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task ActivarInactivarModulo(Guid moduloId)
    {
        var regActualizar = await _moduloRepositorioLectura
            .Query(x => x.ModuloId == moduloId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Modulo), "No se encontró el registro a actualizar");

        regActualizar.Activo = !regActualizar.Activo;

        _moduloRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ConsultarModuloPorIdResponse> ConsultarModuloPorId(Guid moduloId)
    {
        var result = await _moduloRepositorioLectura
            .Query(m => m.ModuloId == moduloId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Modulo), "No se encontró el registro");

        return new ConsultarModuloPorIdResponse(
            result.AplicacionId,
            result.ModuloId,
            result.NombreModulo,
            result.DescModulo,
            result.IconoPrefijo,
            result.IconoNombre,
            result.Orden,
            result.Activo);
    }

    public async Task<IEnumerable<ConsultarModulosResponse>> ConsultarModulos(Guid aplicacionId, bool? activo)
    {
        var filtroEspecificacion = new ModuloEspecificacion(aplicacionId, activo);

        return await _moduloRepositorioLectura
            .Query(filtroEspecificacion.Criteria)
            .SelectAsync(m => new ConsultarModulosResponse(
                m.AplicacionId,
                m.ModuloId,
                m.NombreModulo,
                m.DescModulo,
                m.IconoPrefijo,
                m.IconoNombre,
                m.Orden,
                m.Activo));
    }

    public async Task<CrearModuloResponse> CrearModulo(CrearModuloCommand registroDto)
    {
        var registro = new Modulo
        {
            AplicacionId = registroDto.AplicacionId,
            ModuloId = Guid.NewGuid(),
            NombreModulo = registroDto.NombreModulo,
            DescModulo = registroDto.DescModulo,
            IconoPrefijo = registroDto.IconoPrefijo,
            IconoNombre = registroDto.IconoNombre,
            Orden = registroDto.Orden
        };

        _moduloRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearModuloResponse(
            registro.AplicacionId,
            registro.ModuloId,
            registro.NombreModulo,
            registro.DescModulo,
            registro.IconoPrefijo,
            registro.IconoNombre,
            registro.Orden,
            registro.Activo);
    }

    public async Task EditarModulo(EditarModuloCommand registroDto)
    {
        var regActualizar = await _moduloRepositorioLectura
            .Query(x => x.ModuloId == registroDto.ModuloId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Modulo), "No se encontró el registro a actualizar");

        regActualizar.NombreModulo = registroDto.NombreModulo;
        regActualizar.DescModulo = registroDto.DescModulo;
        regActualizar.IconoPrefijo = registroDto.IconoPrefijo;
        regActualizar.IconoNombre = registroDto.IconoNombre;
        regActualizar.Orden = registroDto.Orden;

        _moduloRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();
    }
}
