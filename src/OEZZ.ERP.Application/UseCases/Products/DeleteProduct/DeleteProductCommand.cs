using MediatR;
using OEZZ.ERP.Application.Base;

namespace OEZZ.ERP.Application.UseCases.Products.DeleteProduct;

public record DeleteProductCommand(Guid id) : IRequest<IResult>;