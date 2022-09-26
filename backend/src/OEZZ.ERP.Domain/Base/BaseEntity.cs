using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Domain.Base;

public abstract class BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Status Status { get; set; }
}