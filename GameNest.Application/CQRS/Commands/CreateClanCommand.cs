﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GameNest.Application.CQRS.Commands
{
    public class CreateClanCommand : IRequest<Clan>
    {
        public string Name { get; set; }
    }

    public class CreateClanCommandHandler(IHttpContextAccessor httpContextAccessor, IPlayerRepository playerRepository, IClanRepository clanRepository) : IRequestHandler<CreateClanCommand, Clan>
    {
        public async Task<Clan> Handle(CreateClanCommand command, CancellationToken cancellationToken)
        {
            httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
            var guid = Guid.Parse(token);
            var requester = await playerRepository.GetByGuidAsync(guid);

            if (requester == null)
            {
                throw new Exception("Requester not found");
            }

            if (requester.Clan != null)
            {
                throw new Exception("Requester is already in a clan");
            }

            var clan = new Clan()
            {
                Name = command.Name,
            };

            return await clanRepository.AddAsync(clan);
        }
    }
}
