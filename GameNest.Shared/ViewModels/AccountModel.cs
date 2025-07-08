using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Coin { get; set; }
        public int Cash { get; set; }
        public LoadoutModel? Loadout { get; set; }
        public List<ItemInstanceModel> Items { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
