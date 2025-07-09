using AutoMapper;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using GameNest.Shared.MessagePacks;
using GameNest.Shared.ViewModels;
using MediatR;

namespace GameNest.Application.CQRS.Requests.Auth;

public class RegisterRequest : IRequest<RegisterResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class RegisterRequestHandler(IAccountRepository accountRepository,IItemRepository itemRepository,ILoadoutRepository loadoutRepository,IMapper mapper) : IRequestHandler<RegisterRequest, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var player = new Account
        {
            Username = request.Username,
            Password = request.Password,
            Email = request.Email,
            Level = 1,
            Coin = 1000,
            Cash = 100,
            Items = new List<ItemInstance>()
        };

        try
        {
            // İlgili itemları bul
            var m4a1 = await itemRepository.GetByNameAsync("M4A1");
            var glock = await itemRepository.GetByNameAsync("Glock-18");
            var armor = await itemRepository.GetByNameAsync("Body Armor");
            if (m4a1 == null || glock == null || armor == null)
                throw new Exception("Starter items not found.");

            // ItemInstance oluştur
            var m4a1Instance = new ItemInstance { Id = Guid.NewGuid(), Item = m4a1, Account = player };
            var glockInstance = new ItemInstance { Id = Guid.NewGuid(), Item = glock, Account = player };
            var armorInstance = new ItemInstance { Id = Guid.NewGuid(), Item = armor, Account = player };
            player.Items.Add(m4a1Instance);
            player.Items.Add(glockInstance);
            player.Items.Add(armorInstance);

            // 1. Adım: Account'u kaydet (Id oluşsun)
            await accountRepository.CreateAsync(player);

            // 2. Adım: Loadout'u oluştur, AccountId'yi set et
            var loadout = new Domain.Entities.Loadout
            {
                Id = Guid.NewGuid(),
                AccountId = player.Id,
                Main = m4a1Instance,
                Secondary = glockInstance,
                Chest = armorInstance,
                Account = player
            };
            player.Loadout = loadout;
            player.LoadoutId = loadout.Id;

            // 3. Adım: Loadout'u context üzerinden ekle ve kaydet
            // (AccountRepository'de context'e erişim yoksa, burada context ile eklenmeli)
            await loadoutRepository.CreateLoadoutAsync(loadout);

            // 4. Adım: Account'un LoadoutId'sini güncelle
            await accountRepository.UpdateAsync(player);

            // 5. Adım: Account'u ilişkili verilerle tekrar çek
            var fullAccount = await accountRepository.GetByUsernameAsync(player.Username);

            return new RegisterResponse
            {
                Success = true,
                Message = "Registration successful"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RegisterResponse
            {
                Success = false,
                Message = $"Registration failed: {e.Message}"
            };
        }
    }
}