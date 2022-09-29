﻿using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Domain.Specifications.Subcategories;

namespace OEZZ.ERP.Application.UseCases.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, IResult<CreateProductDto>>
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Subcategory, Guid> _subcategoryRepository;

    public CreateProductHandler(
        IRepository<Product, Guid> productRepository,
        IRepository<Subcategory, Guid> subcategoryRepository
    )
    {
        _productRepository = productRepository;
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task<IResult<CreateProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var companyExists = await _subcategoryRepository.Any(new SubcategoryExistsSpecification(request.SubcategoryId), cancellationToken);
        if (!companyExists)
        {
            return GenericResult.Bad<CreateProductDto>($"Subcategory {request.SubcategoryId} not found");
        }

        var product = new Product(request.Name, request.SubcategoryId);
        await _productRepository.Add(product, cancellationToken);

        return new CreateProductDto(product.Id, product.SubcategoryId, product.Name).Ok();
    }
}