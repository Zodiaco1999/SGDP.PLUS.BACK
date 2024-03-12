using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ObtenerInforme.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ObtenerInforme;

public record struct ObtenerInformeResponse(
    EmpresaSintesisInternacional TerceroInfoBasica,
    int numAdministradores,
    List<AdministradorDto> Administradores);

