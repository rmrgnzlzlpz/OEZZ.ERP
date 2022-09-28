using MediatR;
using OEZZ.ERP.Application.Base;

namespace OEZZ.ERP.Application.UseCases.Users;

public record UserLoginCommand(string Username, string Password)
    : IRequest<IResult<UserLoginDto>>;