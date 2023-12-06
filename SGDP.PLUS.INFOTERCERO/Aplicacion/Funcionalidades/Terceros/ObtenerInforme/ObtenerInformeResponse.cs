using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;

public record struct ObtenerInformeResponse(
    EmpresaSintesisInternacional TerceroInfoBasica,
    int numAdministradores,
    List<Administrador> Administradores);

