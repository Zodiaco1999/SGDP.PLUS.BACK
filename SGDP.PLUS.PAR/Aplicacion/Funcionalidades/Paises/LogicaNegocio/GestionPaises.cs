using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Especificacion;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;
using System.Data.Entity;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

public class GestionPaises : BaseAppService, IGestionPaises
{
    private readonly IPaisRepositorioLectura _paisRepositorioLectura;
    private readonly IPaisRepositorioEscritura _paisRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionPaises(
        IPaisRepositorioLectura paisRepositorioLectura,
        IPaisRepositorioEscritura paisRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _paisRepositorioLectura = paisRepositorioLectura;
        _paisRepositorioEscritura = paisRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarPaisResponse> ActivarInactivarPais(Guid paisId)
    {
        var regActualizar = await _paisRepositorioEscritura.Query(x => x.PaisId == paisId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _paisRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _paisRepositorioEscritura.Query(x => x.PaisId == paisId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarPaisResponse(
            regActualizado.PaisId,
            regActualizado.Nombre,
            regActualizado.Codigo, 
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<ConsultarPaisPorIdResponse> ConsultarPaisPorId(Guid paisId)
    {
        var result = await _paisRepositorioLectura.Query(p => p.PaisId == paisId).FirstOrDefaultAsync();


        return new ConsultarPaisPorIdResponse(
            result.PaisId,
            result.Nombre,
            result.Codigo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Activo
            );

    }

    public async Task<DataViewModel<ConsultaPaisesResponse>> ConsultarPaises(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PaisEspecificacion(filtro);

            var result = await _paisRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultaPaisesResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultaPaisesResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultaPaisesResponse(
                                item.PaisId,
                                item.Nombre,
                                item.Codigo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha,
                                item.Activo
                                );
                consulta.Data.Add(det);
            }
            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Pais), ex.Message);
        }
    }

    public async Task<CrearPaisResponse> CrearPais(CrearPaisCommand registroDto)
    {
        var registro = new Pais
        {
            Nombre = registroDto.Nombre,
            Codigo = registroDto.Codigo

        };

        _paisRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearPaisResponse(
            registro.PaisId,
            registro.Nombre,
            registro.Codigo,
            registro.Activo
            );
    }

    public async Task<EditarPaisResponse> EditarPais(EditarPaisCommand registroDto)
    {
        var regActualizar = await _paisRepositorioEscritura.Query(x => x.PaisId == registroDto.PaisId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Pais), "No se encontró el registro a actualizar");
        }

        regActualizar.Nombre = registroDto.Nombre;
        regActualizar.Codigo = registroDto.Codigo;

        _paisRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _paisRepositorioEscritura.Query(x => x.PaisId == registroDto.PaisId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Pais), "No se encontró el registro actualizado");
        }

        return new EditarPaisResponse(
            regActualizado.PaisId,
            regActualizado.Nombre,
            regActualizado.Codigo,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<IEnumerable<ListaPaisesResponse>> ListaPaises()
    {
        var paises = await _paisRepositorioLectura
            .Query(p => p.Activo)
            .SelectAsync();

        IEnumerable<ListaPaisesResponse> response = paises.Select(p => new ListaPaisesResponse(
            p.PaisId,
            p.Nombre,
            p.Codigo,
            p.CreaUsuario,
            p.CreaFecha,
            p.ModificaMaquina,
            p.ModificaFecha,
            p.Activo));

        return response;
    }
}
