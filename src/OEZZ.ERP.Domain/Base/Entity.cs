namespace OEZZ.ERP.Domain.Base;

public class Entity<T> : BaseEntity, IEntity<T>
{
    public virtual T Id { get; set; } = default!;
}