using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OEZZ.ERP.API.Security;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.UseCases.Products.CreateProduct;
using OEZZ.ERP.Application.UseCases.Products.ListProducts;
using OEZZ.ERP.Application.UseCases.Users;
using IResult = OEZZ.ERP.Application.Base.IResult;

namespace OEZZ.ERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly TokenHelper _tokenHelper;

    public UsersController(IMediator mediator, TokenHelper tokenHelper)
    {
        _mediator = mediator;
        _tokenHelper = tokenHelper;
    }

    [HttpPost("generate-token")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginCommand command)
    {
        var response = await _mediator.Send(command);
        if (!response.Success)
        {
            return StatusCode(response.Code, response);
        }

        if (response.Data is null)
        {
            return Conflict();
        }

        return Ok(new { Token = _tokenHelper.CreateToken(response.Data) });
    }
}