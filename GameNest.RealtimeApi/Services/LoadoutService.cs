using System.Security.Claims;
using AutoMapper;
using GameNest.Application.CQRS.Queries;
using GameNest.Application.CQRS.Requests.Loadout;
using GameNest.Shared.Services;
using GameNest.Shared.ViewModels;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GameNest.RealtimeApi.Services;

[Authorize]
public class LoadoutService(IMediator mediator,IMapper mapper) : ServiceBase<ILoadoutService>, ILoadoutService
{
    public async UnaryResult<LoadoutModel> GetLoadoutAsync()
    {
        try
        {
            var accountId = Context.CallContext.GetHttpContext().User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var accountGuid = Guid.Parse(accountId.Value);
            var request = new GetLoadoutByAccountIdRequest()
            {
                AccountId = accountGuid
            };
            var result = await mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async UnaryResult<LoadoutModel> GetLoadoutByIdAsync(Guid loadoutId)
    {
        try
        {
            var request = new GetLoadoutByIdRequest()
            {
                LoadoutId = loadoutId
            };
            var result = await mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async UnaryResult<LoadoutModel> SaveLoadoutAsync(LoadoutModel loadout)
    {
        try
        {
            var accountId = Context.CallContext.GetHttpContext().User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var accountGuid = Guid.Parse(accountId.Value);
            var request = new SaveLoadoutRequest()
            {
                Loadout = loadout
            };
            var result = await mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}