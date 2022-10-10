using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common.DTOs;

namespace OEZZ.ERP.Application.UseCases.Products.ListProducts;

public record ListProductsQuery(
    int Top = 10,
    int Skip = 0,
    string Search = "",
    string Order = "asc",
    string OrderBy = "name"
) : PaginationQuery(Top, Skip, Search, Order, OrderBy), IRequest<IResult<PaginatedResponse<ProductDto>>>;