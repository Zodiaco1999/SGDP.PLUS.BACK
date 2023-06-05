using Ardalis.GuardClauses;
using Azure.Core;
using Microsoft.Win32;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Especificacion;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

public class GestionPerfiles : IGestionPerfiles
{
    private readonly IPerfilRepositorioLectura _perfilRepositorioLectura;
    private readonly IPerfilRepositorioEscritura _perfilRepositorioEscritura;

    public GestionPerfiles(IPerfilRepositorioLectura perfilRepositorioLectura, IPerfilRepositorioEscritura perfilRepositorioEscritura)
    {
        _perfilRepositorioLectura = perfilRepositorioLectura;
        _perfilRepositorioEscritura = perfilRepositorioEscritura;
    }

    public async Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null)
    {
        try
        {
            var filtroEspecificacion = new PerfilEspecificacion(filtro);

            DataViewModel<ConsultarPerfilesResponse> consulta = new DataViewModel<ConsultarPerfilesResponse>();

            var result = await _perfilRepositorioLectura
                .Query(filtroEspecificacion.Criteria)
                .OrderBy(ordenarPor!, direccionOrdenamientoAsc.GetValueOrDefault())
                .SelectPageAsync(pagina, registrosPorPagina);

            consulta.TotalRecords = result.TotalItems;
            consulta.Data = new List<ConsultarPerfilesResponse>();

            foreach (var item in result.Items!)
            {
                var det = new ConsultarPerfilesResponse(
                                item.PerfilId,
                                item.NombrePerfil,
                                item.DescPerfil,
                                item.Activo,
                                item.CreaUsuario,
                                item.CreaFecha,
                                item.ModificaUsuario,
                                item.ModificaFecha);
                consulta.Data.Add(det);
            }

            return consulta;
        }
        catch (Exception ex)
        {
            throw new NotFoundException(nameof(Perfil), ex.Message);
        }
    }

    public async Task<CrearPerfilesResponse> CrearPerfil(CrearPerfilesCommand registroDto)
    {
        var registro = new Perfil() { NombrePerfil = registroDto.NombrePerfil, DescPerfil = registroDto.DescPerfil };

        await _perfilRepositorioEscritura.InsertAsync(registro);

        return new CrearPerfilesResponse(registro.PerfilId, registro.NombrePerfil, registro.DescPerfil, registro.Activo);
    }

    public async Task<ActivarInactivarPerfilesResponse> ActivarInactivar(Guid perfilId)
    {
        var regActualizar = await _perfilRepositorioEscritura.Query(x => x.PerfilId == perfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizar");
        }
        regActualizar.Activo = !regActualizar.Activo;

        await _perfilRepositorioEscritura.UpdateAsync(regActualizar);

        var regActualizado = await _perfilRepositorioEscritura.Query(x => x.PerfilId == perfilId).FirstOrDefaultAsync(); 
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro actualizado");
        }

        return new ActivarInactivarPerfilesResponse(
            regActualizado.PerfilId,
            regActualizado.NombrePerfil,
            regActualizado.DescPerfil,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }

    public async Task<ConsultarPerfilPorIdResponse> ConsultarPerfil(Guid perfilId)
    {
        var result = await _perfilRepositorioLectura
            .Query(p => p.PerfilId == perfilId)
            .Include(p => p.PerfilMenu!)
            //.Include(p => p.UsuarioPerfiles)
            .FirstOrDefaultAsync();

        if (result.PerfilMenu is not null) result.PerfilMenu.Perfil = null!; 

        return new ConsultarPerfilPorIdResponse(
            result.PerfilId,
            result.NombrePerfil,
            result.DescPerfil,
            result.Activo,
            result.CreaUsuario,
            result.CreaFecha,
            result.ModificaUsuario,
            result.ModificaFecha,
            result.PerfilMenu);
    }

    public async Task<EditarPerfilesResponse> ActualizarPerfil(EditarPerfilesCommand registroDto)
    {
        var regActualizar = await _perfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();

        if (regActualizar is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizar");
        }

        regActualizar.NombrePerfil = registroDto.NombrePerfil;
        regActualizar.DescPerfil = registroDto.DescPerfil;

        await _perfilRepositorioEscritura.UpdateAsync(regActualizar);

        var regActualizado = await _perfilRepositorioEscritura.Query(x => x.PerfilId == registroDto.PerfilId).FirstOrDefaultAsync();
        if (regActualizado is null)
        {
            throw new NotFoundException(nameof(Perfil), "No se encontró el registro a actualizado");
        }

        return new EditarPerfilesResponse(
            regActualizado.PerfilId,
            regActualizado.NombrePerfil,
            regActualizado.DescPerfil,
            regActualizado.Activo,
            regActualizado.CreaUsuario,
            regActualizado.CreaFecha,
            regActualizado.ModificaUsuario,
            regActualizado.ModificaFecha);
    }
}
