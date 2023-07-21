using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SGDP.PLUS.Comun.Entidades;

public class CamposLogSoftDelete : CamposLog
{
    [DefaultValue(false)]
    public bool? IsDeleted { get; set; }

    [NotMapped]
    public bool NotSoftDelete { get; set; }
}
