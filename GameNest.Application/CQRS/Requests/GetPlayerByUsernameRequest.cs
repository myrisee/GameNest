using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Queries
{
    public class GetPlayerByUsernameRequest : IRequest<Account>
    {
        public string Username { get; set; }
    }

    public class GetPlayerByUsernameRequestHandler(IAccountRepository accountRepository) : IRequestHandler<GetPlayerByUsernameRequest, Account>
    {
        public async Task<Account?> Handle(GetPlayerByUsernameRequest request, CancellationToken cancellationToken)
        {
            return await accountRepository.GetByUsernameAsync(request.Username);
        }
    }
}
