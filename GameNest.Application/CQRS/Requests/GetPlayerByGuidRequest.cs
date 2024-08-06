using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Queries
{
    public class GetPlayerByGuidRequest : IRequest<Player>
    {
        public Guid Id { get; set; }
    }

    public class GetPlayerByGuidRequestHandler(IPlayerRepository playerRepository) : IRequestHandler<GetPlayerByGuidRequest, Player>
    {
        public Task<Player> Handle(GetPlayerByGuidRequest request, CancellationToken cancellationToken)
        {
            return playerRepository.GetByGuidAsync(request.Id);
        }
    }
}
