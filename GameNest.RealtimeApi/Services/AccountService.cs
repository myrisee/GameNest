using System.Security.Claims;
using AutoMapper;
using GameNest.Application.CQRS.Queries;
using GameNest.Shared.Services;
using GameNest.Shared.ViewModels;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GameNest.RealtimeApi.Services;

[Authorize]
public class AccountService(IMediator mediator, IMapper mapper) : ServiceBase<IAccountService>, IAccountService
{
    public async UnaryResult<AccountModel> GetCurrentAccountAsync()
    {
        try
        {
            var accountId = Context.CallContext.GetHttpContext().User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var accountGuid = Guid.Parse(accountId.Value);
            var request = new GetAccountByGuidRequest()
            {
                Id = accountGuid
            };
            var result = await mediator.Send(request);
            return mapper.Map<AccountModel>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}