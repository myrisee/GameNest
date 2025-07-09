using System;
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
    public class CreateClanRequest : IRequest<Clan>
    {
        public string Name { get; set; }
    }

    public class CreateClanCommandHandler(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository, IClanRepository clanRepository) : IRequestHandler<CreateClanRequest, Clan>
    {
        public async Task<Clan> Handle(CreateClanRequest request, CancellationToken cancellationToken)
        {
            httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
            var guid = Guid.Parse(token);
            var requester = await accountRepository.GetByGuidAsync(guid);

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
                Name = request.Name,
            };

            return await clanRepository.AddAsync(clan);
        }
    }
}
