using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SEG.Comun.Entidades;

public class CamposLogSoftDelete : CamposLog
{
    [DefaultValue(false)]
    public bool? IsDeleted { get; set; }

    [NotMapped]
    public bool NotSoftDelete { get; set; }
}
