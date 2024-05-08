namespace SGDP.PLUS.Comun.General;

public class GetEntityQuery
{
    public int Pagina { get; set; } = 1;
    public int RegistrosPorPagina { get; set; } = 20;
    public string TextoBusqueda { get; set; } = "";
    public string OrdenarPor { get; set; } = "";
    public string OrdenamientoAsc { get; set; } = "asc";
}
