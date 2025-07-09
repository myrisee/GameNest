using AutoMapper;
using GameNest.Application.Interfaces;
using GameNest.Shared.ViewModels;
using MediatR;

namespace GameNest.Application.CQRS.Requests.Loadout;

public class GetLoadoutByAccountIdRequest : IRequest<LoadoutModel>
{
    public Guid AccountId { get; set; }
}

public class GetLoadoutRequestHandler(ILoadoutRepository loadoutRepository,IMapper mapper) : IRequestHandler<GetLoadoutByAccountIdRequest, LoadoutModel>
{
    public async Task<LoadoutModel> Handle(GetLoadoutByAccountIdRequest request, CancellationToken cancellationToken)
    {
        var loadout = await loadoutRepository.GetLoadoutByAccountIdAsync(request.AccountId);
        if (loadout == null)
        {
            throw new KeyNotFoundException($"Loadout not found for AccountId: {request.AccountId}");
        }
        
        return mapper.Map<LoadoutModel>(loadout);
    }
}

