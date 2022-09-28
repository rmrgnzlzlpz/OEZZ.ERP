using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common;
using OEZZ.ERP.Application.Common.DTOs;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Domain.Specifications.Products;

namespace OEZZ.ERP.Application.UseCases.Products.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, IResult<PaginatedResponse<ProductDto>>>
{
    private readonly IRepository<Product, Guid> _productRepository;

    public ListProductsHandler(IRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IResult<PaginatedResponse<ProductDto>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        ListProductsSpecification specification = new(
            request.Top,
            request.Skip,
            request.Search,
            request.Order.IsAscending(),
            request.OrderBy
        );
        IEnumerable<Product> products = await _productRepository.GetBy(specification, cancellationToken);
        int totalProducts = await _productRepository.Count(specification, cancellationToken);
        PaginatedResponse<ProductDto> paginatedResponse = new(
            Data: products.Select(x => new ProductDto(x.SubcategoryId, x.Name, x.Status, x.CreatedAt, x.UpdatedAt)),
            TotalRecords: totalProducts
        );

        return paginatedResponse.Ok();
    }
}