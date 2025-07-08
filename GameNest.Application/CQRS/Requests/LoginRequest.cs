using GameNest.Application.Interfaces;
using GameNest.Shared.MessagePacks;
using GameNest.Shared.Services;
using MediatR;

namespace GameNest.Application.CQRS.Requests;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginRequestHandler(IAccountRepository accountRepository,IJwtProvider jwtProvider) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var accountInfo = await accountRepository.GetByUsernameAndPasswordAsync(request.Username, request.Password);
        if (accountInfo == null)
        {
            return new LoginResponse();
        }
        
        var token = jwtProvider.GenerateToken(accountInfo);
        Console.WriteLine($"Generated token for user {accountInfo.Username}: {token}");
        
        return new LoginResponse
        {
            Token = token,
            Username = accountInfo.Username
        };
    }
}