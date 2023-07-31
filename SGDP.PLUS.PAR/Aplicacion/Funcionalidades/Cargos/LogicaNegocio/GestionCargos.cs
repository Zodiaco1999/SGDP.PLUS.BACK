using Ardalis.GuardClauses;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Especificacion;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Especificacion;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

public class GestionCargos : BaseAppService, IGestionCargos
{
    private readonly ICargoRepositorioLectura _cargoRepositorioLectura;
    private readonly ICargoRepositorioEscritura _cargoRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura  _unitOfWork;
    private readonly IContextAccessor _contextAccessor;

    public GestionCargos(
        ICargoRepositorioLectura cargoRepositorioLectura,
        ICargoRepositorioEscritura cargoRepositorioEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _cargoRepositorioLectura = cargoRepositorioLectura;
        _cargoRepositorioEscritura = cargoRepositorioEscritura;
        _unitOfWork = unitOfWork;
        _contextAccessor = contextAccessor;
    }

    public async Task<ActivarInactivarCargoResponse> ActivarInactivarCargo(Guid cargoId)
    {
        var regActualizar = await _cargoRepositorioEscritura.Query(x => x.CargoId == cargoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Ciudad), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        _cargoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _cargoRepositorioEscritura.Query(x => x.CargoId == cargoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(TipoPersona), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarCargoResponse(
            regActualizado.CargoId,
            regActualizado.Nombre,
            regActualizado.Abreviatura,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );
    }

    public async Task<ConsultarCargoPorIdResponse> ConsultarCargoPorId(Guid cargoId)
    {
        var result = await _cargoRepositorioLectura.Query(p => p.CargoId == cargoId).FirstOrDefaultAsync();


        return new ConsultarCargoPorIdResponse(
            result.CargoId,
            result.Nombre,
            result.Abreviatura,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.Activo
            );
    }

    public async Task<DataViewModel<ConsultarCargosResponse>> ConsultarCargos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new CargoEspecificacion(filtro);

            var result = await _cargoRepositorioLectura.Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            DataViewModel<ConsultarCargosResponse> consulta = new(pagina, registrosPorPagina, result.TotalItems);

            consulta.Data = new List<ConsultarCargosResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarCargosResponse(
                                item.CargoId,
                                item.Nombre,
                                item.Abreviatura,
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
            throw new NotFoundException(nameof(Cargo), ex.Message);
        }
    }

    public async Task<CrearCargoResponse> CrearCargo(CrearCargoCommand registroDto)
    {
        var registro = new Cargo
        {
            Nombre = registroDto.Nombre,
            Abreviatura = registroDto.Abreviatura

        };

        _cargoRepositorioEscritura.Insert(registro);
        await _unitOfWork.SaveChangesAsync();

        return new CrearCargoResponse(
            registro.CargoId,
            registro.Nombre,
            registro.Abreviatura,
            registro.Activo
            );
    }

    public async Task<EditarCargoResponse> EditarCargo(EditarCargoCommand registroDto)
    {
        var regActualizar = await _cargoRepositorioEscritura.Query(x => x.CargoId == registroDto.CargoId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Cargo), "No se encontró el registro a actualizar");
        }

        regActualizar.Nombre = registroDto.Nombre;
        regActualizar.Abreviatura = registroDto.Abreviatura;

        _cargoRepositorioEscritura.Update(regActualizar);
        await _unitOfWork.SaveChangesAsync();

        var regActualizado = await _cargoRepositorioEscritura.Query(x => x.CargoId == registroDto.CargoId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Ciudad), "No se encontró el registro actualizado");
        }

        return new EditarCargoResponse(
            regActualizado.CargoId,
            regActualizado.Nombre,
            regActualizado.Abreviatura,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha,
            regActualizado.Activo
            );

    }
}