using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ActivarInactivar;

public record struct ActivarInactivarMenuCommand(Guid menuId) : IRequest<ActivarInactivarMenuResponse>;