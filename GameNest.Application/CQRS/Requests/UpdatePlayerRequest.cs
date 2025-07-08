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
    public class UpdatePlayerRequest : IRequest<Account>
    {
        public Account Account { get; set; }
    }

    public class UpdatePlayerRequestHandler(IAccountRepository accountRepository) : IRequestHandler<UpdatePlayerRequest, Account>
    {
        public Task<Account> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
        {
            return accountRepository.UpdateAsync(request.Account);
        }
    }
}
