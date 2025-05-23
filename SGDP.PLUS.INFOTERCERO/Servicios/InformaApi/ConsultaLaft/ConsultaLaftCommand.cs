﻿using MediatR;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft;

public record struct ConsultaLaftCommand(
    string Identificacion,
    string Nombre = "",
    string Monitoreo = "N") : IRequest<ConsultaLaftResponse>;
