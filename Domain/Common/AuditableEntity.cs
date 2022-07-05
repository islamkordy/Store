using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class AuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    [MaxLength(255)]
    public string CreatedBy { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? UpdatedBy { get; set; }
}
