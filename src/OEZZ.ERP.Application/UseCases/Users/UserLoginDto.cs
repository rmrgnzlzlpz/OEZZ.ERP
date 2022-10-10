namespace OEZZ.ERP.Application.UseCases.Users;

public record UserLoginDto(Guid Id, Guid TenantId, string Username, string RefreshToken);