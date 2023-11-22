using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Repositorio;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

public class GestionCiudades : BaseAppService, IGestionCiudades
{
    private readonly ICiudadRepositorioLectura _ciudadRepositorioLectura;
    private readonly ICiudadRepositorioEscritura _ciudadRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionCiudades(
        ICiudadRepositorioLectura ciudadRepositorioLectura,
        ICiudadRepositorioEscritura ciudadRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _ciudadRepositorioLectura = ciudadRepositorioLectura;
        _ciudadRepositorioEscritura = ciudadRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarCiudadResponse> ActivarInactivarCiudad(Guid ciudadId)
    {
        var regActualizar = await _ciudadRepositorioEscritura.Query(x => x.CiudadId == ciudadId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Ciudad), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _ciudadRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _ciudadRepositorioEscritura.Query(x => x.CiudadId == ciudadId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarCiudadResponse(
            regActualizado.CiudadId,
            regActualizado.DepartamentoId,
            regActualizado.Nombre,
            regActualizado.Codigo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<ConsultarCiudadPorIdResponse> ConsultarCiudadPorId(Guid ciudadId)
    {
        var result = await _ciudadRepositorioLectura.Query(p => p.CiudadId == ciudadId).FirstOrDefaultAsync();


        return new ConsultarCiudadPorIdResponse(
            result.CiudadId,
            result.DepartamentoId,
            result.Nombre,
            result.Codigo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Activo
            );
    }

    public async Task<DataViewModel<ConsultarCiudadesResponse>> ConsultarCiudades(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new CiudadEspecificacion(filtro);

            var result = await _ciudadRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarCiudadesResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarCiudadesResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarCiudadesResponse(
                                item.CiudadId,
                                item.DepartamentoId,
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
            throw new NotFoundException(nameof(Ciudad), ex.Message);
        }
    }

    public async Task<CrearCiudadResponse> CrearCiudad(CrearCiudadCommand registroDto)
    {
        var registro = new Ciudad
        {
            DepartamentoId = registroDto.DepertamentoId,
            Nombre = registroDto.Nombre,
            Codigo = registroDto.Codigo

        };

        _ciudadRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearCiudadResponse(
            registro.CiudadId,
            registro.DepartamentoId,
            registro.Nombre,
            registro.Codigo,
            registro.Activo
            );
    }

    public async Task<EditarCiudadResponse> EditarCiudad(EditarCiudadCommand registroDto)
    {
        var regActualizar = await _ciudadRepositorioEscritura.Query(x => x.CiudadId == registroDto.CiudadId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Ciudad), "No se encontró el registro a actualizar");
        }

        regActualizar.DepartamentoId = registroDto.DepartamentoId;
        regActualizar.Nombre = registroDto.Nombre;
        regActualizar.Codigo = registroDto.Codigo;

        _ciudadRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _ciudadRepositorioEscritura.Query(x => x.CiudadId == registroDto.CiudadId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Ciudad), "No se encontró el registro actualizado");
        }

        return new EditarCiudadResponse(
            regActualizado.CiudadId,
            regActualizado.DepartamentoId,
            regActualizado.Nombre,
            regActualizado.Codigo,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );

    }

}