using AutoMapper;
using GameNest.Application.Interfaces;
using GameNest.Shared.ViewModels;
using MediatR;

namespace GameNest.Application.CQRS.Requests.Loadout;

public class GetLoadoutByIdRequest : IRequest<LoadoutModel>
{
    public Guid LoadoutId { get; set; }
}

public class GetLoadoutByIdRequestHandler(ILoadoutRepository loadoutRepository,IMapper mapper) : IRequestHandler<GetLoadoutByIdRequest, LoadoutModel>
{
    public async Task<LoadoutModel> Handle(GetLoadoutByIdRequest request, CancellationToken cancellationToken)
    {
        var loadout = await loadoutRepository.GetLoadoutByIdAsync(request.LoadoutId);
        if (loadout == null)
        {
            throw new KeyNotFoundException($"Loadout with ID {request.LoadoutId} not found.");
        }
        
        return mapper.Map<LoadoutModel>(loadout);;
    }
}