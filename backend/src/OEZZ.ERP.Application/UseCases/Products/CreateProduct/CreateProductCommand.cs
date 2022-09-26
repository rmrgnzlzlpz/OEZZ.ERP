using MediatR;
using OEZZ.ERP.Application.Base;

namespace OEZZ.ERP.Application.UseCases.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    Guid SubcategoryId,
    Guid CompanyId
) : ByCompanyCommand(CompanyId), IRequest<IResult<CreateProductDto>>;