using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Specifications;

public abstract class EntityExistsSpecification<T> : BaseSpecification<T> where T : BaseEntity, IEntity<Guid>
{
    protected EntityExistsSpecification(Guid id)
    {
        Query = entity => entity.Id == id;
    }
}