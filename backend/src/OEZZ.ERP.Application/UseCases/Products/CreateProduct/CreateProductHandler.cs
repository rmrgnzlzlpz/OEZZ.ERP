using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Domain.Specifications.Companies;

namespace OEZZ.ERP.Application.UseCases.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, IResult<CreateProductDto>>
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Company, Guid> _companyRepository;

    public CreateProductHandler(
        IRepository<Product, Guid> productRepository,
        IRepository<Company, Guid> companyRepository
    )
    {
        _productRepository = productRepository;
        _companyRepository = companyRepository;
    }

    public async Task<IResult<CreateProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var companyExists = await _companyRepository.Any(new CompanyExistsSpecification(request.CompanyId), cancellationToken);
        if (!companyExists)
        {
            return GenericResult.Bad<CreateProductDto>($"Compañía {request.CompanyId} no existe");
        }
        
        var product = new Product(request.CompanyId, request.Name, request.SubcategoryId);
        await _productRepository.Add(product, cancellationToken);

        return new CreateProductDto(product.Id, product.SubcategoryId, product.Name).Ok();
    }
}