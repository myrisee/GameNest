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
    public class GetAccountByGuidRequest : IRequest<Account>
    {
        public Guid Id { get; set; }
    }

    public class GetAccountByGuidRequestHandler(IAccountRepository accountRepository) : IRequestHandler<GetAccountByGuidRequest, Account>
    {
        public Task<Account> Handle(GetAccountByGuidRequest request, CancellationToken cancellationToken)
        {
            return accountRepository.GetByGuidAsync(request.Id);
        }
    }
}
