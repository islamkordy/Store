namespace Domain.Common;

public class AuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string LastUpdatedBy{ get; set; }
}
