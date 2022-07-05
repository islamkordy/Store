using Domain.Common;

namespace Domain.Entities;

public class Product : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category Categories { get; set; }
}
