using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.ActivarInactivar;

public record struct ActivarInactivarMenuCommand(Guid menuId) : IRequest<ActivarInactivarMenuResponse>;