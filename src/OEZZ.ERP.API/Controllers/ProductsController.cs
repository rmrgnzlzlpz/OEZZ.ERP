using MediatR;
using Microsoft.AspNetCore.Mvc;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common.DTOs;
using OEZZ.ERP.Application.UseCases.Products.CreateProduct;
using OEZZ.ERP.Application.UseCases.Products.DeleteProduct;
using OEZZ.ERP.Application.UseCases.Products.ListProducts;
using IResult = OEZZ.ERP.Application.Base.IResult;

namespace OEZZ.ERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult<CreateProductDto>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(IResult))]
    public async Task<ActionResult<IResult<CreateProductDto>>> CreateProduct(CreateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.Code, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IResult<PaginatedResponse<ProductDto>>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(IResult))]
    public async Task<ActionResult<IResult<PaginatedResponse<ProductDto>>>> ListProducts([FromQuery] ListProductsQuery query)
    {
        var response = await _mediator.Send(query);
        return StatusCode(response.Code, response);
    }

    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType(typeof(IResult))]
    [ProducesErrorResponseType(typeof(IResult))]
    public async Task<ActionResult<IResult>> DeleteProduct(Guid id)
    {
        var response = await _mediator.Send(new DeleteProductCommand(id));
        return StatusCode(response.Code, response);
    }
}