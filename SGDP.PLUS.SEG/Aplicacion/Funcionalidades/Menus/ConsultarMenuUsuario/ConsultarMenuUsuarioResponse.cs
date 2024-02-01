namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;

public record struct ConsultarMenuUsuarioResponse(
    Guid Id,
    string NameAplication,
    string DescAplication,
    IEnumerable<Module> Modules);

public record struct Module(
    Guid Id,
    string Name,
    string SubName,
    string IconPrefix,
    string IconName,
    IEnumerable<ModuleOption> Options);

public record struct ModuleOption(
    Guid Id,
    string Name,
    string SubName,
    string Url,
    int Order,
    bool Create,
    bool Read,
    bool Update,
    bool Activate,
    bool Delete,
    bool Execute,
    bool MenuCreate,
    bool MenuRead,
    bool MenuUpdate,
    bool MenuActivate,
    bool MenuDelete,
    bool MenuExecute); 