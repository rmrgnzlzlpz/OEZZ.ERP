using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Company : Entity<Guid>
{
    public string Name { get; set; }
}