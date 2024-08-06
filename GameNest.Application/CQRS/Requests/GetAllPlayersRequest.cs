using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;
using GameNest.Application.Interfaces;

namespace GameNest.Application.CQRS.Requests
{
    public class GetAllPlayersRequest : IRequest<List<Player>>{}

    public class GetAllPlayerRequestHandler(IPlayerRepository playerRepository) : IRequestHandler<GetAllPlayersRequest, List<Player>>
    {
        public Task<List<Player>> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            return playerRepository.GetAllAsync();
        }
    }
}
