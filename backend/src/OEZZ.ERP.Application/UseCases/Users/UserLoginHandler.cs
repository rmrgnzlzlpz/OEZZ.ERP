using MediatR;
using OEZZ.ERP.Application.Base;
using OEZZ.ERP.Application.Common;

namespace OEZZ.ERP.Application.UseCases.Users;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, IResult<UserLoginDto>>
{
    public Task<IResult<UserLoginDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new UserLoginDto(Guid.NewGuid(), Guid.NewGuid(), "rmrgnzlz", Guid.NewGuid().ToString()).Ok());
    }
}