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
    public class GetItemInstanceByIdRequest : IRequest<ItemInstance>
    {
        public Guid Id { get; set; }
    }

    public class GetItemInstanceByIdRequestHandler(IItemInstanceRepository itemInstanceRepository) : IRequestHandler<GetItemInstanceByIdRequest, ItemInstance>
    {
        public Task<ItemInstance> Handle(GetItemInstanceByIdRequest request, CancellationToken cancellationToken)
        {
            return itemInstanceRepository.GetByInstanceIdAsync(request.Id);
        }
    }
}
