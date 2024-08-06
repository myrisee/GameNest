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
    public class CreateItemCommand : IRequest<Item>
    {
        public string Name { get; set; } = "Default Item";
        public string Description { get; set; } = "Default Description";
        public uint Rarity { get; set; } = 0;
        public uint Level { get; set; } = 1;
        public uint CoinPrice { get; set; } = 0;
        public uint CashPrice { get; set; } = 0;
    }

    public class CreateItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<CreateItemCommand, Item>
    {
        public Task<Item> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = command.Name,
                Description = command.Description,
                Rarity = command.Rarity,
                Level = command.Level,
                CoinPrice = command.CoinPrice,
                CashPrice = command.CashPrice
            };

            return itemRepository.AddAsync(item);
        }
    }
}
