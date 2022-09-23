using MediatR;

namespace OEZZ.ERP.Application.UseCases.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductDTO>
{
    public CreateProductHandler()
    {
    }
    public Task<CreateProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}