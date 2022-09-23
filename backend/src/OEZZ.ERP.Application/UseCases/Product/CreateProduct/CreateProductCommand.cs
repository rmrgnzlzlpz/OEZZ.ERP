using MediatR;

namespace OEZZ.ERP.Application.UseCases.Product.CreateProduct;

public record CreateProductCommand(
    string Name,
    Guid SubcategoryId,
    Guid CompanyId
) : IRequest<CreateProductDTO>;