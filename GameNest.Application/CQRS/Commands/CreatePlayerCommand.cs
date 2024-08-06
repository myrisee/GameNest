using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Commands
{
    public class CreatePlayerCommand : IRequest<Player>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CreatePlayerCommandHandler(IPlayerRepository playerRepository) : IRequestHandler<CreatePlayerCommand, Player>
    {
        public async Task<Player> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Username = command.Username,
                Password = command.Password,
                Level = 1,
                Coin = 1000,
                Cash = 100
            };

            return await playerRepository.CreateAsync(player);
        }
    }
}
