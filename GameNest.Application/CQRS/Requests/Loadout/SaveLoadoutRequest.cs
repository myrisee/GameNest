using AutoMapper;
using GameNest.Application.Interfaces;
using GameNest.Shared.ViewModels;
using MediatR;

namespace GameNest.Application.CQRS.Requests.Loadout;

public class SaveLoadoutRequest : IRequest<LoadoutModel>
{
    public LoadoutModel Loadout { get; set; }
}

public class SaveLoadoutRequestHandler(ILoadoutRepository loadoutRepository, IMapper mapper) : IRequestHandler<SaveLoadoutRequest, LoadoutModel>
{
    public async Task<LoadoutModel> Handle(SaveLoadoutRequest request, CancellationToken cancellationToken)
    {
        if (request.Loadout == null)
        {
            throw new ArgumentNullException(nameof(request.Loadout), "Loadout cannot be null");
        }

        var loadoutEntity = mapper.Map<Domain.Entities.Loadout>(request.Loadout);
        var savedLoadout = await loadoutRepository.SaveLoadoutAsync(loadoutEntity);

        return mapper.Map<LoadoutModel>(savedLoadout);
    }
}