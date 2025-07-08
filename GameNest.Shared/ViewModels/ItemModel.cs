using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class ItemModel
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Rarity { get; set; }
        public uint Level { get; set; }
        public uint CoinPrice { get; set; }
        public uint CashPrice { get; set; }
    }
}
