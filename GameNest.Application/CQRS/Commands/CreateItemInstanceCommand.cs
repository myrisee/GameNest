using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using MediatR;

namespace GameNest.Application.CQRS.Commands
{
    public class CreateItemInstanceCommand : IRequest<ItemInstance>
    {
        public uint ItemId { get; set; }
        public Guid PlayerId { get; set; }
    }

    public class CreateItemInstanceCommandHandler(IItemInstanceRepository itemInstanceRepository, IItemRepository itemRepository) : IRequestHandler<CreateItemInstanceCommand, ItemInstance>
    {
        public async Task<ItemInstance> Handle(CreateItemInstanceCommand command, CancellationToken cancellationToken)
        {
            var item = await itemRepository.GetByIdAsync(command.ItemId);

            var itemInstance = new ItemInstance
            {
                Item = item,
                PlayerId = command.PlayerId
            };

            return await itemInstanceRepository.AddAsync(itemInstance);
        }
    }
}
