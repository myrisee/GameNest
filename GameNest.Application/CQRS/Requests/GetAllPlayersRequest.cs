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
    public class GetAllPlayersRequest : IRequest<List<Account>>{}

    public class GetAllPlayerRequestHandler(IAccountRepository accountRepository) : IRequestHandler<GetAllPlayersRequest, List<Account>>
    {
        public Task<List<Account>> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            return accountRepository.GetAllAsync();
        }
    }
}
