using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Domain.Base;

public abstract class BaseEntity
{
    public virtual Status Status { get; init; }
}