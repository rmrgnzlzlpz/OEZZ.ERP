using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Ports;

namespace OEZZ.ERP.Application.UseCases.Products.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, IResult>
{
    private readonly IRepository<Product, Guid> _productRepository;

    public DeleteProductHandler(IRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindAsync(request.id, cancellationToken);
        if (product is null)
        {
            return GenericResult.Bad("Product not found");
        }

        await _productRepository.DeleteAsync(product, cancellationToken);

        return GenericResult.Ok();
    }
}