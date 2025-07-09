using AutoMapper;
using GameNest.Application.CQRS.Requests;
using GameNest.Application.CQRS.Requests.Auth;
using GameNest.Shared.MessagePacks;
using GameNest.Shared.Services;
using MagicOnion;
using MagicOnion.Server;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GameNest.RealtimeApi.Services;

public class AuthService(IMapper mapper,IMediator mediator) : ServiceBase<IAuthService>, IAuthService
{
    [AllowAnonymous]
    public async UnaryResult<LoginResponse> LoginAsync(LoginMessage message)
    {
        try
        {
            var request = mapper.Map<LoginRequest>(message);
            return await mediator.Send(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [AllowAnonymous]
    public async UnaryResult<RegisterResponse> RegisterAsync(RegisterMessage message)
    {
        try
        {
            var request = mapper.Map<RegisterRequest>(message);
            return await mediator.Send(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}