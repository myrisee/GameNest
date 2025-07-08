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
    public class GetPlayerByGuidRequest : IRequest<Account>
    {
        public Guid Id { get; set; }
    }

    public class GetPlayerByGuidRequestHandler(IAccountRepository accountRepository) : IRequestHandler<GetPlayerByGuidRequest, Account>
    {
        public Task<Account> Handle(GetPlayerByGuidRequest request, CancellationToken cancellationToken)
        {
            return accountRepository.GetByGuidAsync(request.Id);
        }
    }
}
