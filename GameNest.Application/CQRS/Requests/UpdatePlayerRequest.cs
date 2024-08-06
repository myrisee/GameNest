using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Requests
{
    public class UpdatePlayerRequest : IRequest<Player>
    {
        public Player Player { get; set; }
    }

    public class UpdatePlayerRequestHandler(IPlayerRepository playerRepository) : IRequestHandler<UpdatePlayerRequest, Player>
    {
        public Task<Player> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
        {
            return playerRepository.UpdateAsync(request.Player);
        }
    }
}
