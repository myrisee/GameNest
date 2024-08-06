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
    public class GetItemByNameRequest : IRequest<Item>
    {
        public string Name { get; set; }
    }

    public class GetItemByNameRequestHandler(IItemRepository itemRepository) : IRequestHandler<GetItemByNameRequest, Item>
    {
        public Task<Item> Handle(GetItemByNameRequest request, CancellationToken cancellationToken)
        {
            return itemRepository.GetByNameAsync(request.Name);
        }
    }
}
