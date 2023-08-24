using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Lista;

 public record struct ListaTipoDocumentoResponse(
        int TipoDocumentoId,
        string? Nombre,
        string? Abreviatura,
        bool Activo);
    
    

