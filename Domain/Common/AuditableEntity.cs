namespace Domain.Common;

public class AuditableEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string CreatedBy { get; set; } = "Default";

    public DateTime LastUpdatedDate { get; set; } = DateTime.Now;

    public string LastUpdatedBy{ get; set; } = "Default";
}
