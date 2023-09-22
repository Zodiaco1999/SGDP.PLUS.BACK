namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;

public record struct ConsultarMenuUsuarioResponse(
    Guid Id,
    string Name,
    string Desc,
    List<Module> Modules);

public record struct Module(
    Guid Id,
    string Name,
    string SubName,
    bool Active,
    string IconPrefix,
    string IconName,
    List<ModuleOption> Options);

public record struct ModuleOption(
    Guid Id,
    string Name,
    string SubName,
    string Url,
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