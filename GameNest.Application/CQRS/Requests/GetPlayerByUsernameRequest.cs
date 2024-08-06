using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Queries
{
    public class GetPlayerByUsernameRequest : IRequest<Player>
    {
        public string Username { get; set; }
    }

    public class GetPlayerByUsernameRequestHandler(IPlayerRepository playerRepository) : IRequestHandler<GetPlayerByUsernameRequest, Player>
    {
        public async Task<Player?> Handle(GetPlayerByUsernameRequest request, CancellationToken cancellationToken)
        {
            return await playerRepository.GetByUsernameAsync(request.Username);
        }
    }
}
