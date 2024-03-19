using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme;

public record struct ObtenerInformeResponse(
    EmpresaSintesisInternacional TerceroInfoBasica,
    int numAdministradores,
    List<AdministradorDto> Administradores);

