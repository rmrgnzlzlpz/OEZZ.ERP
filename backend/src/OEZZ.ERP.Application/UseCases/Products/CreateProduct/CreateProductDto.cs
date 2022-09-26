namespace OEZZ.ERP.Application.UseCases.Products.CreateProduct;

public record CreateProductDto(
    Guid Id,
    Guid SubcategoryId,
    string Name
);