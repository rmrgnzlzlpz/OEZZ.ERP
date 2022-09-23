namespace OEZZ.ERP.Application.UseCases.Product.CreateProduct;

public record CreateProductDTO(
    Guid Id,
    Guid SubcategoryId,
    string Name
);