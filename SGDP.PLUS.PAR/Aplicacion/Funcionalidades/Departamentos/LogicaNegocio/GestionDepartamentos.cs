using Ardalis.GuardClauses;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Especificacion;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

public class GestionDepartamentos : BaseAppService, IGestionDepartamentos
{
    private readonly IDepartamentoRepositorioLectura _departamentoRepositorioLectura;
    private readonly IDepartamentoRepositorioEscritura _departamentoRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionDepartamentos(
        IDepartamentoRepositorioLectura departamentoRepositorioLectura,
        IDepartamentoRepositorioEscritura departamentoRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _departamentoRepositorioLectura = departamentoRepositorioLectura;
        _departamentoRepositorioEscritura = departamentoRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarDepartamentoResponse> ActivarInactivarDepartamento(Guid departamentoId)
    {
        var regActualizar = await _departamentoRepositorioEscritura.Query(x => x.DepartamentoId == departamentoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _departamentoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _departamentoRepositorioEscritura.Query(x => x.DepartamentoId == departamentoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarDepartamentoResponse(
            regActualizado.DepartamentoId,
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

    public async Task<ConsultarDepartamentoPorIdResponse> ConsultarDepartamentoPorId(Guid departamentoId)
    {
        var result = await _departamentoRepositorioLectura.Query(p => p.DepartamentoId == departamentoId).FirstOrDefaultAsync();


        return new ConsultarDepartamentoPorIdResponse(
            result.DepartamentoId,
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

    public async Task<DataViewModel<ConsultarDepartamentosResponse>> ConsultarDepartamentos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new DepartamentoEspecificacion(filtro);

            var result = await _departamentoRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarDepartamentosResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarDepartamentosResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarDepartamentosResponse(
                                item.DepartamentoId,
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
            throw new NotFoundException(nameof(Departamento), ex.Message);
        }
    }

    public async Task<CrearDepartamentoResponse> CrearDepartamento(CrearDepartamentoCommand registroDto)
    {
        var registro = new Departamento
        {
            PaisId = registroDto.PaisId,
            Nombre = registroDto.Nombre,
            Codigo = registroDto.Codigo

        };

        _departamentoRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearDepartamentoResponse(
            registro.DepartamentoId,
            registro.PaisId,
            registro.Nombre,
            registro.Codigo,
            registro.Activo
            );
    }

    public async Task<EditarDepartamentoResponse> EditarDepartamento(EditarDepartamentoCommand registroDto)
    {
        var regActualizar = await _departamentoRepositorioEscritura.Query(x => x.DepartamentoId == registroDto.DepartamentoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Departamento), "No se encontró el registro a actualizar");
        }

        regActualizar.PaisId = registroDto.PaisId;
        regActualizar.Nombre = registroDto.Nombre;
        regActualizar.Codigo = registroDto.Codigo;

        _departamentoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _departamentoRepositorioEscritura.Query(x => x.DepartamentoId == registroDto.DepartamentoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Departamento), "No se encontró el registro actualizado");
        }

        return new EditarDepartamentoResponse(
            regActualizado.DepartamentoId,
            regActualizado.PaisId,
            regActualizado.Nombre,
            regActualizado.Codigo,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );

    }
}