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
    public class GetItemByIdRequest : IRequest<Item>
    {
        public uint Id { get; set; }
    }

    public class GetItemByIdRequestHandler(IItemRepository itemRepository) : IRequestHandler<GetItemByIdRequest, Item>
    {
        public Task<Item> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            return itemRepository.GetByIdAsync(request.Id);
        }
    }
}
