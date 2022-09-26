using MediatR;
using Microsoft.AspNetCore.Mvc;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.UseCases.Products.CreateProduct;
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
        return Ok(await _mediator.Send(command));
    }
}